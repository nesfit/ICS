namespace Example
{
    public class Dog: Animal
    {
        string _coatColor;           // Class member - field
        int _length;                 // Class member - field

        public override string Cry()// Class member - method
        {
            return "Woof!";
        }

        public void Bite() { }      // Class member - method
    }
}