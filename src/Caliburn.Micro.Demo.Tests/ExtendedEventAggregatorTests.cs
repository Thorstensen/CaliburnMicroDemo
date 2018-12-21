using Autofac;
using Caliburn.Micro.Demo.EventAggregation;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using Caliburn.Micro.Demo.Extensions;
using Autofac.Features.Indexed;
using System;

namespace Caliburn.Micro.Demo.Tests
{
    public class ExtendedEventAggregatorTests
    {
        [Fact]
        public void EventAggregator_GivenEventAndAlwaysTrueGuard_ShouldPublishToAllSubscribers()
        {
            var componentContextFake = Substitute.For<IIndex<string, IExecuteGuard>>();
            var eventAggregator = new ExtendedEventAggregator(componentContextFake);

            var mySubscribingObject = new MyHandlingObject();
            eventAggregator.Subscribe(mySubscribingObject);

            eventAggregator.PublishOnUIThread(new MyEvent(2));

            mySubscribingObject.Id.Should().Be(2);
        }

        [Fact]
        public void EventAggregator_GivenGuardWhichReturnsFalse_ShouldNotFireEvent()
        {
            var componentContextFake = Substitute.For<IIndex<string, IExecuteGuard>>();
            var eventAggregator = new ExtendedEventAggregator(componentContextFake);

            var @object = new Object1();
            eventAggregator.Subscribe(@object);

            eventAggregator.PublishOnUIThread(new MyEvent(1));

            @object.EventHandled.Should().BeFalse();
        }


        [Fact]
        public void EventAggregator_GivenGuardWithDependencies_ShouldFireEventToAllSubscribers()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            containerBuilder.RegisterCommandGuard<MustBeAdminGuard>();
            containerBuilder.RegisterType<ExtendedEventAggregator>().As<IEventAggregator>();
            var container = containerBuilder.Build();

            using (var lifeTimeScope = container.BeginLifetimeScope())
            {
                var eventAggregator = lifeTimeScope.Resolve<IEventAggregator>();
                var @object = new ObjectWhichHandlesUsers();
                eventAggregator.Subscribe(@object);

                @object.AddUsers(1);
                @object.AddUsers(2);
                @object.AddUsers(3);

                eventAggregator.PublishOnUIThread(new FireEmployeeCommand(userId: 1, userToFireId: 2));
                @object.UserIds.Should().HaveCount(2);
            }
        }

        [Fact]
        public void EventAggregator_GivenTwoClassesSubscribingToSameEvent_ShouldUpdateBothSubscribers()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ExtendedEventAggregator>().As<IEventAggregator>();
            var container = containerBuilder.Build();

            using (var lifeTimeScope = container.BeginLifetimeScope())
            {
                var eventAggregator = lifeTimeScope.Resolve<IEventAggregator>();

                var obj1 = new Class1();
                eventAggregator.Subscribe(obj1);

                var obj2 = new Class2();
                eventAggregator.Subscribe(obj2);

                eventAggregator.PublishOnUIThread(new AwesomeEvent(10));

                obj1.Id.Should().Be(10);
                obj2.Id.Should().Be(10);
            }
        }

        [Fact]
        public void EventAggregator_GivenClassSubscribingTwice_ShouldThrowArgumentException()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ExtendedEventAggregator>().As<IEventAggregator>();
            var container = containerBuilder.Build();

            using (var lifeTimeScope = container.BeginLifetimeScope())
            {
                var eventAggregator = lifeTimeScope.Resolve<IEventAggregator>();
                var obj = new Object1();

                Assert.Throws<ArgumentException>(() =>
                {
                    eventAggregator.Subscribe(obj);
                    eventAggregator.Subscribe(obj);
                });
            }
        }

        [Fact]
        public void EventAggregator_GivenClassWhichSubscribesOnce_ShouldNotBeInListWhenUnsubscribedIsCalled()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ExtendedEventAggregator>().As<IEventAggregator>();
            var container = containerBuilder.Build();

            using (var lifeTimeScope = container.BeginLifetimeScope())
            {
                var eventAggregator = lifeTimeScope.Resolve<IEventAggregator>();
                var obj = new Object1();
                eventAggregator.Subscribe(obj);

                var first = eventAggregator.HandlerExistsFor(typeof(MyEvent));
                first.Should().BeTrue();

                eventAggregator.Unsubscribe(obj);
                var second = eventAggregator.HandlerExistsFor(typeof(MyEvent));
                second.Should().BeFalse();
            } 
        }
 
        #region Faked objects for test setups

        #region Test setup 1
        public interface IUserRepository
        {
            bool IsUserInAdminGroup(int userid);
        }
        public class UserRepository : IUserRepository
        {
            Dictionary<int, List<string>> _users = new Dictionary<int, List<string>>
        {
            {1, new List<string>() {"Admin", "Region vest"} },
            {2, new List<string>() {"Admin", "Region øst"} }
        };

            public bool IsUserInAdminGroup(int userid)
            {
                var list = _users.Where(p => p.Key == userid).Select(r => r.Value);
                if (list.Any(p => p.Any(i => i.Equals("Admin"))))
                    return true;
                return false;
            }
        }

        public class MustBeAdminGuard : IExecuteGuard
        {
            private readonly IUserRepository _userRepository;

            public MustBeAdminGuard(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public bool CanExecute(object obj)
            {
                var @event = obj as FireEmployeeCommand;
                var canHandle = _userRepository.IsUserInAdminGroup(@event.UserId);
                return canHandle;
            }
        }

        public class FireEmployeeCommand : IUserEvent
        {
            public int UserId { get; private set; }
            public int UserToFireId { get; private set; }

            public FireEmployeeCommand(int userId, int userToFireId)
            {
                UserId = userId;
                UserToFireId = userToFireId;
            }
        }

        public class ObjectWhichHandlesUsers : ICanHandle<FireEmployeeCommand, MustBeAdminGuard>
        {
            public List<int> UserIds = new List<int>();

            public void AddUsers(int id)
            {
                UserIds.Add(id);
            }

            public void Handle(FireEmployeeCommand command)
            {
                var id = UserIds.FirstOrDefault(p => p == command.UserToFireId);
                UserIds.Remove(id);
            }
        }

        public interface IUserEvent
        {
            int UserId { get; }
        }


        #endregion

        #region Test setup 2
        public class Object1 : ICanHandle<MyEvent, ValueMustBeGreaterThanGuard>
        {
            public bool EventHandled { get; private set; }

            public void Handle(MyEvent command)
            {
                EventHandled = true;
            }
        }
        public class ValueMustBeGreaterThanGuard : IExecuteGuard
        {
            public bool CanExecute(object obj)
            {
                var value = (MyEvent)obj;
                return value.Id > 5;
            }
        }
        public class MyHandlingObject : ICanHandle<MyEvent, AlwaysTrueGuard>
        {
            public int Id { get; private set; }

            public void Handle(MyEvent command)
            {
                Id = command.Id;
            }
        }
        public class MyEvent
        {
            public MyEvent(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
        #endregion

        #region Test setup 3

        public class Class1 : ICanHandle<AwesomeEvent, AlwaysTrueGuard>
        {
            public int Id { get; private set; }
            public void Handle(AwesomeEvent @event)
            {
                Id = @event.Id;
            }
        }

        public class Class2 : ICanHandle<AwesomeEvent, AlwaysTrueGuard>
        {
            public int Id { get; private set; }
            public void Handle(AwesomeEvent @event)
            {
                Id = @event.Id;
            }
        }

        public class AwesomeEvent
        {
            public int Id { get; private set; }
            public AwesomeEvent(int id)
            {
                Id = id;
            }
        }

        #endregion

     
        #endregion
    }
}
