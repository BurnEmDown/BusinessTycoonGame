using System;
using System.Collections.Generic;
using System.Linq;

namespace Managers.Events
{
    public class EventsManager
    {
        public Dictionary<EventType, EventListenersData> ListenersData = new();

        public void AddListener(EventType eventType, Action<object> additionalData)
        {
            if (ListenersData.TryGetValue(eventType, out var value))
            {
                value.ActionsOnInvoke.Add(additionalData);
            }
            else
            {
                ListenersData[eventType] = new EventListenersData(additionalData);
            }
        }

        public void RemoveListener(EventType eventType, Action<object> actionToRemove)
        {
            if (!ListenersData.TryGetValue(eventType, out var value))
            {
                return;
            }

            value.ActionsOnInvoke.Remove(actionToRemove);

            if (!value.ActionsOnInvoke.Any())
            {
                ListenersData.Remove(eventType);
            }
        }

        public void InvokeEvent(EventType eventType, object dataToInvoke)
        {
            if (!ListenersData.TryGetValue(eventType, out var value))
            {
                return;
            }

            foreach (var action in value.ActionsOnInvoke)
            {
                action.Invoke(dataToInvoke);
            }
        }
    }

}