namespace Exercise_3
{
    public interface ITextWriter
    {
        void Write(string message, MessageType type = MessageType.Normal);
    }
}