using Examples;
using Xunit;

namespace Lecture02.Tests
{
    public class UpCast
    {
        [Fact]
        public void UpCastTest()
        {
            var dog = new Dog();
            Animal animal = dog; //Upcast
            Assert.Equal(animal, dog);
        }
    }
}