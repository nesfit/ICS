using Xunit.Sdk;

namespace CookBook.Common.Tests;

public class ObjectEqualException(object? expected, object? actual, string message)
    : AssertActualExpectedException(expected, actual, "Assert.Equal() Failure")
{
    public override string Message { get; } = message;
}
