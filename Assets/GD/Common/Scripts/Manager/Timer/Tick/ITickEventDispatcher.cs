using System;

namespace GD.Utility
{
    public interface ITickEventDispatcher
    {
        void Register(ITickStrategy strategy, Action callback);

        void Unregister(ITickStrategy strategy, Action callback);

        void Notify(int tickCount);
    }
}