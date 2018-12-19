using System;

namespace Caliburn.Micro.Demo.Framework
{
    public static class Guard
    {
        public static Against Against => new Against();
    }

    public sealed class Against
    {
        public void Null<T>(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
        }

        public void Equality<T>(T value, Func<T> exepectedValue)
        {
            var compliedExpectedValue = exepectedValue();
            var equal = value.Equals(compliedExpectedValue);
            if (value == null || value.Equals(compliedExpectedValue))
                throw new ArgumentException($"Give value '{value}' does not match the expected value '{compliedExpectedValue}'");
        }

        public void InEquality<T>(T value, Func<T> expectedValue)
        {
            var compliedExpectedValue = expectedValue();
            var equal = value.Equals(compliedExpectedValue);
            if (value == null || !value.Equals(compliedExpectedValue))
                throw new ArgumentException($"Give value '{value}' does not match the expected value '{compliedExpectedValue}'");
        }

        public void ReferenceEquality<T>(T @this, Func<T> other)
        {
            var compiledReference = other();
            if (@this == null || ReferenceEquals(@this, compiledReference))
                throw new ArgumentException($"Given object {@this} is equal to {compiledReference}");
        }
    }

   
}
