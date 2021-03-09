namespace Examples
{
    public abstract class Pet : Animal
    {
        public string Name { get; private set; } = "PET";
        
        protected Pet(string name)
        {
            Name = name;
        }
    }
}