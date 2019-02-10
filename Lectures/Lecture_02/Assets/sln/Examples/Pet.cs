namespace Examples
{
    public abstract class Pet : Animal
    {
        public string Name { get; protected set; } = "PET";

        protected Pet()
        {
            
        }

        protected Pet(string name)
        {
            this.Name = name;
        }
    }
}