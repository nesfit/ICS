namespace Examples
{
    public class WildCat: Pet
    {
        public WildCat()
        {
        }

        public WildCat(string name):base(name)
        {
            
        }

        public override string Cry()
        {
            return "Meow!";
        }
    }
}