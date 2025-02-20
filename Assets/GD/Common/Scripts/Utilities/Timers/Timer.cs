using UnityEngine;

namespace GD.Utility
{
    /// <summary>
    /// Support stopwatch and countdown timer functionality.
    /// </summary>
    public class Timer
    {
        private bool isRunning = false;
        private float startTime = 0;

        private float elapsedUpdateTime = 0;
        private float elapsedFixedTime = 0;

        public virtual void Start(int time = 0) => Reset(time);

        public virtual void Reset(int time) => elapsedUpdateTime = elapsedFixedTime = time;

        public virtual void Stop()
        {
        }

        public virtual void Update() => elapsedUpdateTime += Time.deltaTime;

        public virtual void FixedUpdate() => elapsedFixedTime += Time.fixedDeltaTime;
    }
}