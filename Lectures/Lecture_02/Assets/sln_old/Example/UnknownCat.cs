namespace Example
{
    public class UnknownCat: Animal
    {
        public string Name { get; set; } = "Default Name";

        public UnknownCat()
        {
        }

        public UnknownCat(string name)
        {
            Name = name;
        }

        public override string Cry()
        {
            return "Meow!";
        }
    }
}