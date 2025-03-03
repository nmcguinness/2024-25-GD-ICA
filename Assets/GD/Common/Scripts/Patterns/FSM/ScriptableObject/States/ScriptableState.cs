using GD.Types;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace GD.FSM.SO
{
    [Serializable]
    [CreateAssetMenu(fileName = "ScriptableState", menuName = "GD/FSM/Scriptable/State")]
    public class ScriptableState : ScriptableGameObject
    {
        #region Fields

        [FoldoutGroup("Actions & Transitions", expanded: true)]
        [SerializeField]
        protected ScriptableAction[] actions;

        [FoldoutGroup("Actions & Transitions")]
        [SerializeField]
        protected ScriptableTransition[] transitions;

        #endregion Fields

        #region Properties

        public ScriptableAction[] Actions { get => actions; }
        public ScriptableTransition[] Transitions { get => transitions; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        public virtual void OnEnter(ScriptableStateController stateController)
        {
            for (int i = 0; i < actions.Length; i++)
                actions[i].OnEnter(stateController);
        }

        /// <summary>
        /// Used for states that relate to game logic or other variable time updates.
        /// </summary>
        public void UpdateState(ScriptableStateController stateController)
        {
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
        }

        #endregion Methods
    }
}