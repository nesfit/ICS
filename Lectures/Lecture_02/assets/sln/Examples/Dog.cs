using System;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Tests")]

namespace Examples
{
    public class Dog: Pet
    {
        private int _age; // Class member - field

        internal Dog(): base(string.Empty) { }
        public Dog(string name): base(name) { }

        public int Age // Class member - property with backing field
        {
            get => _age;
            set => _age = value;
        }
        // Class member - auto-generated property
        public string Breed { get; protected set; } = "Akita";

        public override string Cry()   // Class member - method
            => "Woof!";
        public void Bite() { /*...*/ } // Class member - method
    }
}