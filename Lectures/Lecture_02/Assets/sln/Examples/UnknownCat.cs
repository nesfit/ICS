namespace Examples
{
    public class UnknownCat: Pet
    {
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