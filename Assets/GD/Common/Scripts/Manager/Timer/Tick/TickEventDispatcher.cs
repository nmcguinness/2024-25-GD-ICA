using System;
using System.Collections.Generic;

namespace GD.Utility
{
    public class TickEventDispatcher : ITickEventDispatcher
    {
        private readonly Dictionary<ITickStrategy, List<Action>> listeners = new();

        public void Register(ITickStrategy strategy, Action callback)
        {
            if (!listeners.ContainsKey(strategy))
                listeners[strategy] = new List<Action>();

            listeners[strategy].Add(callback);
        }

        public void Unregister(ITickStrategy strategy, Action callback)
        {
            if (listeners.ContainsKey(strategy))
            {
                listeners[strategy].Remove(callback);
            }
        }

        public void Notify(int tickCount)
        {
            foreach (var entry in listeners)
            {
                if (entry.Key.TickEvery(tickCount))
                {
                    foreach (var callback in entry.Value)
                    {
                        callback.Invoke();
                    }
                }
            }
        }
    }
}