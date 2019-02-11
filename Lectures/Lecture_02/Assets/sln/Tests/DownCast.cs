using System;
using Examples;
using Xunit;

namespace Lecture02.Tests
{
    public class DownCast
    {
        [Fact]
        public void DownCastTest()
        {
            Animal animal = new Dog();
            var dog = (Dog)animal; //Downcast
            Assert.Equal(animal, dog);
        }

        [Fact]
        public void DownCastFailTest()
        {
            object dog = new Dog();
            Assert.Throws<InvalidCastException>(() => (Panda)dog);
        }
    }
}