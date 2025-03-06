namespace GD.Utility
{
    /// <summary>
    /// A simple count-up timer that tracks elapsed time while running.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Indicates whether the timer is actively running.
        /// </summary>
        private bool isRunning;

        /// <summary>
        /// Accumulated time in seconds since the timer started.
        /// </summary>
        protected float currentTime;

        /// <summary>
        /// Gets the total elapsed time (in seconds) since the timer began running.
        /// </summary>
        public float ElapsedTime => currentTime;

        protected bool IsRunning { get => isRunning; }

        /// <summary>
        /// Starts the timer from a specified initial time (default is 0).
        /// If the timer was previously running, it is reset to the given initial time
        /// and continues running.
        /// </summary>
        /// <param name="initialTime">
        /// The value (in seconds) from which the timer will begin counting up.
        /// Defaults to 0 if not provided.
        /// </param>
        public virtual void Start(float initialTime = 0f)
        {
            isRunning = true;
            currentTime = initialTime;
        }

        /// <summary>
        /// Increments the timer by the specified deltaTime if the timer is running.
        /// Typically called once per frame (in Update) by a manager or other system.
        /// </summary>
        /// <param name="deltaTime">The time in seconds since the last update call.</param>
        public virtual void Tick(float deltaTime)
        {
            if (isRunning)
                currentTime += deltaTime;
        }

        /// <summary>
        /// Resets the elapsed time to the specified value without changing the running state.
        /// </summary>
        /// <param name="time">The new value (in seconds) to which elapsed time is set.</param>
        public virtual void Reset(float time = 0f)
        {
            currentTime = time;
        }

        /// <summary>
        /// Stops the timer from running. Elapsed time is preserved until it is reset or restarted.
        /// </summary>
        public virtual void Stop()
        {
            isRunning = false;
        }

        /// <summary>
        /// Pauses the timer without resetting its elapsed time.
        /// The timer may be resumed later to continue accumulating time.
        /// </summary>
        public void Pause() => isRunning = false;

        /// <summary>
        /// Resumes the timer from its previously accumulated time if paused.
        /// Has no effect if the timer was already running.
        /// </summary>
        public void Resume() => isRunning = true;

        /// <summary>
        /// Determines whether the elapsed time has reached or exceeded the specified duration.
        /// </summary>
        /// <param name="duration">The duration threshold in seconds.</param>
        /// <returns>True if ElapsedTime >= duration; otherwise, false.</returns>
        public bool HasElapsed(float duration)
        {
            return currentTime >= duration;
        }
    }
}