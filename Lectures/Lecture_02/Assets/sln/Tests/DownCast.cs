using System;
using System.Diagnostics.CodeAnalysis;
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
            Dog dog = (Dog)animal; //Downcast

            Assert.Equal(animal.GetType(), dog.GetType());
        }

        [Fact]
        public void DownCastFailTest()
        {
            object dog = new Dog();

            Assert.Throws<InvalidCastException>(() => (Panda)dog);
        }
    }
}