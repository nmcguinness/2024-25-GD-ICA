using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace GD.Tick
{
    /// <summary>
    /// A singleton class that creates a time-tick system that sends
    /// tick pulses every (1x, 2x, 4x, and 8x) multiple of the base tick rate.
    /// Allows registering and unregistering listeners for different tick rates.
    /// </summary>
    public class TimeTickSystem : Singleton<TimeTickSystem>
    {
        #region Fields

        // Base interval for the tick system in seconds. Each tick occurs every 0.1 seconds by default.
        [SerializeField]
        private float baseTickIntervalSecs = 0.1f;

        // Enum representing different tick rate multipliers.
        public enum TickRateMultiplierType : sbyte
        {
            BaseInterval = 1,    // Fires every tick (base rate)
            HalfBaseInterval = 2,    // Fires every 2 ticks
            QuarterBaseInterval = 4, // Fires every 4 ticks
            EightBaseInterval = 8   // Fires every 8 ticks (8 x 0.03 = 0.24 ~ typical human perception
        }

        // The current tick count, starting from zero.
        public uint Tick { get; private set; } = 0;

        // Timer to keep track of the interval between ticks.
        private float tickTimer;

        // Dictionary holding UnityEvents for each tick rate multiplier type.
        private Dictionary<TickRateMultiplierType, UnityEvent> tickEvents;

        #endregion Fields

        #region Unity Lifecycle

        // Awake is called when the script instance is being loaded.
        private void Awake()
        {
            if (baseTickIntervalSecs <= 0)
                throw new Exception("Tick System Base Tick Interval must be > 0!");

            // Initialize the dictionary to hold UnityEvents for each tick rate multiplier.
            tickEvents = new Dictionary<TickRateMultiplierType, UnityEvent>
            {
                { TickRateMultiplierType.BaseInterval, new UnityEvent() },
                { TickRateMultiplierType.HalfBaseInterval, new UnityEvent() },
                { TickRateMultiplierType.QuarterBaseInterval, new UnityEvent() },
                { TickRateMultiplierType.EightBaseInterval, new UnityEvent() }
            };
        }

        // FixedUpdate is called on a fixed time interval, typically used for physics updates.
        private void FixedUpdate()
        {
            // Increment the timer by the time elapsed since the last frame.
            tickTimer += Time.deltaTime;

            // Check if the timer exceeds the base tick interval.
            if (tickTimer >= baseTickIntervalSecs)
            {
                tickTimer -= baseTickIntervalSecs; // Reset the timer.
                Tick++; // Increment the tick count.

                // Invoke tick events based on the tick rate multipliers.
                tickEvents[TickRateMultiplierType.BaseInterval]?.Invoke();

                if (Tick % (int)TickRateMultiplierType.HalfBaseInterval == 0)
                {
                    tickEvents[TickRateMultiplierType.HalfBaseInterval]?.Invoke();

                    if (Tick % (int)TickRateMultiplierType.QuarterBaseInterval == 0)
                    {
                        tickEvents[TickRateMultiplierType.QuarterBaseInterval]?.Invoke();

                        if (Tick % (int)TickRateMultiplierType.EightBaseInterval == 0)
                        {
                            tickEvents[TickRateMultiplierType.EightBaseInterval]?.Invoke();
                        }
                    }
                }
            }
        }

        #endregion Unity Lifecycle

        #region Public Methods

        /// <summary>
        /// Registers a listener for the specified tick rate type.
        /// </summary>
        /// <param name="tickRateType">The type of tick rate multiplier to listen to.</param>
        /// <param name="listener">The UnityAction to register.</param>
        public void RegisterListener(TickRateMultiplierType tickRateType, UnityAction listener)
        {
            // Check if the dictionary contains the requested tick rate type.
            if (tickEvents.ContainsKey(tickRateType))
            {
                tickEvents[tickRateType].AddListener(listener);
            }
        }

        /// <summary>
        /// Unregisters a listener from the specified tick rate type.
        /// </summary>
        /// <param name="tickRateType">The type of tick rate multiplier to stop listening to.</param>
        /// <param name="listener">The UnityAction to unregister.</param>
        public void UnregisterListener(TickRateMultiplierType tickRateType, UnityAction listener)
        {
            // Check if the dictionary contains the requested tick rate type.
            if (tickEvents.ContainsKey(tickRateType))
            {
                tickEvents[tickRateType].RemoveListener(listener);
            }
        }

        #endregion Public Methods
    }
}