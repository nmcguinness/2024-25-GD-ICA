using System.Collections.Generic;
using UnityEngine;

namespace GD.Utility
{
    public class TimerManager : Singleton<TimerManager>
    {
        private readonly Dictionary<string, Timer> activeTimers = new();

        private void Update()
        {
            foreach (var timer in activeTimers.Values)
                timer.Update();
        }

        private void FixedUpdate()
        {
            foreach (var timer in activeTimers.Values)
                timer.FixedUpdate();
        }

        public void RegisterTimer(Timer timer)
        {
            if (!activeTimers.ContainsKey(timer.Name))
            {
                activeTimers[timer.Name] = timer;
                Debug.Log($"[TimerManager] Registered Timer: {timer.Name}");
            }
        }

        public void UnregisterTimer(Timer timer)
        {
            if (activeTimers.Remove(timer.Name))
            {
                Debug.Log($"[TimerManager] Unregistered Timer: {timer.Name}");
            }
        }

        public void DebugActiveTimers()
        {
            Debug.Log("[TimerManager] Active Timers: " + string.Join(", ", activeTimers.Keys));
        }
    }
}