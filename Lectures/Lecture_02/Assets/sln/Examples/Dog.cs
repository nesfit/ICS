using System;
using System.Collections.Specialized;

namespace Examples
{
    public class Dog: Pet
    {
        private Int32 _age;          // Class member - filed

        public int Age               // Class member - property
        {
            get => _age;
            set => _age = value;
        }

        // Class member - auto-generated property
        public String Breed { get; protected set; } = "Akita";

        public override string Cry() // Class member - method
        {
            return "Woof!";
        }

        public void Bite() { }       // Class member - method
    }
}