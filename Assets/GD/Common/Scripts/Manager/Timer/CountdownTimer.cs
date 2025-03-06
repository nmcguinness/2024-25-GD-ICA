using System;
using UnityEngine;

namespace GD.Utility
{
    /// <summary>
    /// A timer that counts down from a specified duration to zero, raising an event when finished.
    /// Inherits the base Timer (which counts up internally).
    /// </summary>
    public class CountdownTimer : Timer
    {
        // How many seconds to count down from
        private float totalDuration;

        // Event that fires once the timer first finishes
        public event Action<CountdownTimer> OnFinished;

        /// <summary>
        /// Returns how many seconds are left before the countdown finishes.
        /// </summary>
        public float RemainingTime => Mathf.Max(0f, totalDuration - ElapsedTime);

        /// <summary>
        /// True if ElapsedTime >= totalDuration, i.e. the countdown is complete.
        /// </summary>
        public bool IsFinished => ElapsedTime >= totalDuration;

        /// <summary>
        /// Starts the countdown from the given duration.
        /// Internally, this calls the base Timer's Start(0)
        /// so that ElapsedTime begins at 0.
        /// </summary>
        /// <param name="duration">How many seconds to count down from.</param>
        public override void Start(float duration = 0f)
        {
            // Start counting from 0 in the base Timer
            base.Start(0f);

            totalDuration = duration;
        }

        /// <summary>
        /// Ticks the timer forward by deltaTime and triggers OnFinished when done.
        /// If the timer finishes, we Stop() it so it doesn't keep accumulating.
        /// </summary>
        public override void Tick(float deltaTime)
        {
            // Only update if currently running
            if (!IsRunning) return;

            // Let the base Timer handle the accumulation of elapsed time
            base.Tick(deltaTime);

            // Check if we just crossed the finish line
            if (ElapsedTime >= totalDuration)
            {
                // Fire event
                OnFinished?.Invoke(this);

                // Stop the timer to prevent further calls
                Stop();
            }
        }
    }
}