namespace Examples
{
    public class WildCat : Pet
    {
        public WildCat() : this(string.Empty) { }

        protected WildCat(string name) : base(name) { }

        public override string Cry() => "Meow!";
    }
}