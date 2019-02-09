namespace Examples
{
    public abstract class Pet : Animal
    {
        public virtual string Name { get; protected set; } = "PET";
    }
}