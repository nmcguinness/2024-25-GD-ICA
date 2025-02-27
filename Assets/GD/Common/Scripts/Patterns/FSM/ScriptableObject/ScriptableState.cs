using GD.Types;
using GD.Utility;
using System;
using UnityEngine;

namespace GD.FSM.ScriptableObject
{
    [Serializable]
    public abstract class ScriptableState : ScriptableGameObject
    {
        [SerializeField]
        private Blackboard blackboard;

        [NonSerialized]
        private Timer timer;

        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        public virtual void OnEnter()
        {
            Debug.Log(message: $"OnEnter: {GetType().Name} at {Time.time}");

            if (timer == null)
                timer = new Timer(GetType().Name);

            timer.Start(0);
        }

        /// <summary>
        /// Used for states that relate to game logic or other variable time updates.
        /// </summary>
        public virtual void Update()
        {
            timer.Update();
        }

        /// <summary>
        /// Used for states that relate to physics or other fixed time updates.
        /// </summary>
        public virtual void FixedUpdate()
        {
            timer.FixedUpdate();
        }

        /// <summary>
        /// Called when the state is exited.
        /// </summary>
        public virtual void OnExit()
        {
            Debug.Log(message: $"OnExit: {GetType().Name} at {Time.time}");
            timer.Stop();
        }
    }
}