using System.Collections.Generic;
using UnityEngine;

namespace GD.FSM.SO
{
    public class ScriptableStateMachine : MonoBehaviour
    {
        [SerializeField]
        private ScriptableStateController stateController;

        [SerializeField]
        private List<ScriptableState> states = new List<ScriptableState>();

        [SerializeField]
        private ScriptableState initialState;

        [SerializeField]
        private List<ScriptableTransition> anyTransitions = new List<ScriptableTransition>();

        private ScriptableState currentState;

        //TODO: Finish this!
    }
}