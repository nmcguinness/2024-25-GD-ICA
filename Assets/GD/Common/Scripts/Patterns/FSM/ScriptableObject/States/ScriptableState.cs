using GD.Types;
using GD.Utility;
using System;
using UnityEngine;

namespace GD.FSM.SO
{
    [Serializable]
    [CreateAssetMenu(fileName = "ScriptableState", menuName = "GD/FSM/Scriptable/State")]
    public class ScriptableState : ScriptableObject
    {
        [SerializeField]
        private ScriptableAction[] actions;

        [SerializeField]
        private ScriptableTransition[] transitions;

        private Timer timer;

        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        public virtual void OnEnter(ScriptableStateController stateController)
        {
            if (timer == null)
                timer = new Timer(GetType().Name);

            timer.Start(0);

            for (int i = 0; i < actions.Length; i++)
                actions[i].OnEnter(stateController);
        }

        /// <summary>
        /// Used for states that relate to game logic or other variable time updates.
        /// </summary>
        public void UpdateState(ScriptableStateController stateController)
        {
            timer.Update();

            for (int i = 0; i < actions.Length; i++)
                actions[i].OnUpdate(stateController);
        }

        /// <summary>
        /// Called when the state is exited.
        /// </summary>
        public virtual void OnExit(ScriptableStateController stateController)
        {
            for (int i = 0; i < actions.Length; i++)
                actions[i].OnExit(stateController);

            timer.Stop();
        }
    }
}