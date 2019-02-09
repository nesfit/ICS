using Example;
using Xunit;

namespace Tests
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