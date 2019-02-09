namespace Example
{
    public class Cat: UnknownCat
    {
        public int LivesLeft { get; set; } = 9;

        public Cat(string name) : base(name)
        {
        }

        public Cat(string name, int livesLeft) : this(name)
        {
            LivesLeft = livesLeft;
        }
    }
}