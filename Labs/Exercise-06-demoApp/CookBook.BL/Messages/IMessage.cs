using System;
using CookBook.BL.Interfaces;

namespace CookBook.BL.Messages
{
    public interface IMessage
    {
        Guid Id { get; set; }
        Guid TargetId { get; set; }
    }
    public abstract class Message<T> : IMessage where T : IId
    {
        private Guid? _id;

        public Guid Id
        {
            get => _id ?? Model.Id;
            set => _id = value;
        }

        public Guid TargetId { get; set; }
        public T Model { get; set; }
    }

    public class NewMessage<T> : Message<T> where T : IId
    {
    }
    public class DeleteMessage<T> : Message<T> where T : IId
    {
    }
    public class SelectedMessage<T> : Message<T> where T : IId
    {
    }
    public class UpdateMessage<T> : Message<T> where T : IId
    {
    }

}
