namespace Example
{
    public class Dog: Animal
    {
        string coatColor;           // Class member - field
        int length;                 // Class member - field

        public override string Cry()// Class member - method
        {
            return "Woof!";
        }

        public void Bite() { }      // Class member - method
    }
}