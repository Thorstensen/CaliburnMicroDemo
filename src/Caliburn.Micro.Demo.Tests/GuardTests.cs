using Caliburn.Micro.Demo.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Caliburn.Micro.Demo.Tests
{
    public class GuardTests
    {
        [Fact]
        public void Given_NullObject_GuardShouldThrowArgumentNullException()
        {
            MyObject obj = null;
            Assert.Throws<ArgumentNullException>(() => Guard.Against.Null(obj));
        }

        [Fact]
        public void Given_InstansiatedObject_GuardShouldNotThrowArgumentNullException()
        {
            MyObject obj = new MyObject();
            var exception = Record.Exception(() => Guard.Against.Null(obj));
            Assert.Null(exception);
        }

        [Fact]
        public void Given_TwoDifferentObject_GuardShouldThrowArgumentException()
        {
            var obj1 = new MyObject();
            var obj2 = new MyObject();
            Assert.Throws<ArgumentException>(() => Guard.Against.InEquality(obj1, () => obj2));
        }

        [Fact]
        public void Given_TheSameObject_GuardShouldThrowArgumentException()
        {
            var object1 = new MyObject();
            Assert.Throws<ArgumentException>(() => Guard.Against.ReferenceEquality(object1, () => object1));
        }

        [Fact]
        public void Given_TwoDifferentStrings_GuardShouldThrowArgumentException()
        {
            var str1 = "Hello";
            var str2 = "World";

            Assert.Throws<ArgumentException>(() => Guard.Against.InEquality(str1, () => str2));
        }

        [Fact]
        public void Given_TwoEqualStrings_GuardShouldThrowException()
        {
            var str1 = "Hello";
            var str2 = "Hello";

            Assert.Throws<ArgumentException>(() => Guard.Against.Equality(str1, () => str2));
        }
    }

    public class MyObject
    {

    }
}
