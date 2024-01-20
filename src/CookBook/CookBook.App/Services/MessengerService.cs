using CommunityToolkit.Mvvm.Messaging;

namespace CookBook.App.Services;

public class MessengerService(IMessenger messenger) : IMessengerService
{
    public IMessenger Messenger { get; } = messenger;

    public void Send<TMessage>(TMessage message)
        where TMessage : class
    {
        Messenger.Send(message);
    }
}