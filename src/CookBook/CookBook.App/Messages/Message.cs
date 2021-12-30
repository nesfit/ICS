using CookBook.BL.Models;
using System;

namespace CookBook.App.Messages
{
    public abstract class Message<T> : IMessage
        where T : IModel
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
}