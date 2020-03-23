using CookBook.BL.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Services
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Type, List<Delegate>> registeredActions = new Dictionary<Type, List<Delegate>>();

        public void Register<TMessage>(Action<TMessage> action)
            where TMessage : IMessage
        {
            var key = typeof(TMessage);
            if (!registeredActions.TryGetValue(key, out _))
            {
                registeredActions[key] = new List<Delegate>();
            }
            registeredActions[key].Add(action);
        }

        public void UnRegister<TMessage>(Action<TMessage> action)
            where TMessage : IMessage
        {
            var key = typeof(TMessage);

            if (registeredActions.TryGetValue(typeof(TMessage), out var actions))
            {
                var actionsList = actions.ToList();
                actionsList.Remove(action);
                registeredActions[key] = new List<Delegate>(actionsList);
            }
        }

        public void Send<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            if (registeredActions.TryGetValue(typeof(TMessage), out var actions))
            {
                foreach (var action in actions.Select(action => action as Action<TMessage>).Where(action => action != null))
                {
                    action(message);
                }
            }
        }
    }
}
