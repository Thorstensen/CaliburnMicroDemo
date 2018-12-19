﻿using Autofac;
using Caliburn.Micro.Demo.EventAggregation;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using Caliburn.Micro.Demo.Extensions;
using Autofac.Features.Indexed;

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
    }

    #region Faked objects for test setups

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
}
