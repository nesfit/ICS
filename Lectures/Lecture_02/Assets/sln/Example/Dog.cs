namespace Example
{
    public class Dog: Animal
    {
        string coatColor;
        int length;

        public override string Cry()
        {
            return "Woof!";
        }

        public void Bite() { }
    }
}