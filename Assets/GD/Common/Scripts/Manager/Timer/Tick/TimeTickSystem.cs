using System;
using UnityEngine;

namespace GD.Utility
{
    public class TimeTickSystem : Singleton<TimeTickSystem>
    {
        /// <summary>
        /// Base rate of update ticks.
        /// </summary>
        private readonly float updateTickInterval = 0.1f;

        /// <summary>
        /// Base rate of fixed update ticks.
        /// </summary>
        private float fixedTickInterval = 0.02f;

        private ITickEventDispatcher updateTickDispatcher;

        private ITickEventDispatcher fixedTickDispatcher;
        private int updateTickCount = 0;
        private int fixedTickCount = 0;
        private float updateTickTimer = 0;
        private float fixedTickTimer = 0;

        protected override void Awake()
        {
            updateTickDispatcher = new TickEventDispatcher();
            fixedTickDispatcher = new TickEventDispatcher();
        }

        private void Update()
        {
            updateTickTimer += Time.deltaTime;
            if (updateTickTimer >= updateTickInterval)
            {
                updateTickTimer -= updateTickInterval;
                updateTickCount++;
                updateTickDispatcher.Notify(updateTickCount);
            }
        }

        private void FixedUpdate()
        {
            fixedTickTimer += Time.fixedDeltaTime;
            if (fixedTickTimer >= fixedTickInterval)
            {
                fixedTickTimer -= fixedTickInterval;
                fixedTickCount++;
                fixedTickDispatcher.Notify(fixedTickCount);
            }
        }

        public void RegisterUpdateListener(ITickStrategy strategy, Action listener)
        {
            updateTickDispatcher.Register(strategy, listener);
        }

        public void UnregisterUpdateListener(ITickStrategy strategy, Action listener)
        {
            updateTickDispatcher.Unregister(strategy, listener);
        }

        public void RegisterFixedUpdateListener(ITickStrategy strategy, Action listener)
        {
            fixedTickDispatcher.Register(strategy, listener);
        }

        public void UnregisterFixedUpdateListener(ITickStrategy strategy, Action listener)
        {
            fixedTickDispatcher.Unregister(strategy, listener);
        }
    }
}