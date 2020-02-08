using System.Diagnostics.CodeAnalysis;
using Examples;
using Xunit;

namespace Lecture02.Tests
{
    [SuppressMessage("ReSharper", "SuggestVarOrType_SimpleTypes")]
    public class UpCast
    {
        [Fact]
        public void UpCastTest()
        {
            Dog dog = new Dog();
            Animal animal = dog; //Upcast

            Assert.Equal(animal.GetType(), dog.GetType());
        }
    }
}