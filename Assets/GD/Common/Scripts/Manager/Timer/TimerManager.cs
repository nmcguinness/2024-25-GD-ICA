using System.Collections.Generic;
using UnityEngine;

namespace GD.Utility
{
    /// <summary>
    /// A manager that maintains a pool of Timer objects and tracks them by (ID, reference).
    /// </summary>
    /// <see cref="FSM.SO.ScriptableStateMachine"/>
    [DefaultExecutionOrder(-100)]
    public class TimerManager : Singleton<TimerManager>
    {
        [Header("Timer Pool Settings")]
        [SerializeField] private int initialPoolSize = 10;

        // The pool of reusable Timer objects:
        private Queue<Timer> timerPool = new Queue<Timer>();

        // Currently active timers, mapped from TimerKey -> Timer
        private Dictionary<string, Timer> activeTimers = new Dictionary<string, Timer>();

        protected override void Awake()
        {
            base.Awake();

            // Pre-fill the pool with a certain number of Timers.
            for (int i = 0; i < initialPoolSize; i++)
            {
                // By default, name them something like "PooledTimer" (or empty string).
                timerPool.Enqueue(new Timer());
            }
        }

        public void UnregisterTimer(string ID)
        {
            if (activeTimers.TryGetValue(ID, out Timer timer))
            {
                timer.Stop();
                activeTimers.Remove(ID);
                ReturnToPool(timer);
            }
        }

        public void StartTimer(string ID, float duration)
        {
            // If no timer is registered, create it
            if (!activeTimers.TryGetValue(ID, out Timer timer))
            {
                timer = GetFromPool();
                activeTimers[ID] = timer;
            }
            timer.Start(duration);
        }

        public void StopTimer(string ID, object reference)
        {
            if (activeTimers.TryGetValue(ID, out Timer timer))
            {
                timer.Stop();
            }
        }

        public void PauseTimer(string ID)
        {
            if (activeTimers.TryGetValue(ID, out Timer timer))
            {
                timer.Pause();
            }
        }

        public void ResumeTimer(string ID)
        {
            if (activeTimers.TryGetValue(ID, out Timer timer))
            {
                timer.Resume();
            }
        }

        public Timer GetTimer(string ID)
        {
            activeTimers.TryGetValue(ID, out Timer timer);
            return timer;
        }

        public bool HasElapsed(string ID, float duration)
        {
            activeTimers.TryGetValue(ID, out Timer timer);

            if (timer == null)
                Debug.LogError($"Timer with ID {ID} not found.");

            return timer.HasElapsed(duration);
        }

        private List<Timer> tempTimers = new List<Timer>();

        private void Update()
        {
            tempTimers.Clear();
            tempTimers.AddRange(activeTimers.Values);

            foreach (Timer timer in tempTimers)
            {
                timer.Tick(Time.deltaTime);
            }
        }

        private Timer GetFromPool()
        {
            return timerPool.Count > 0 ? timerPool.Dequeue() : new Timer();
        }

        private void ReturnToPool(Timer timer)
        {
            // You might want to reset the timer to a 'fresh' state
            timer.Reset(0);
            // Actually enqueue it so we can reuse the object
            timerPool.Enqueue(timer);
        }
    }
}