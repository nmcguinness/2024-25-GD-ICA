using UnityEngine;
using UnityEngine.AI;

namespace GD.FSM.SO
{
    public class ScriptableStateController : MonoBehaviour
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private NavMeshAgent agent;

        private ScriptableStateMachine stateMachine;

        public Blackboard Blackboard { get => blackboard; }
        public Animator Animator { get => animator; }
        public NavMeshAgent Agent { get => agent; }
        public ScriptableStateMachine ScriptableStateMachine { get => stateMachine; }

        private void Awake()
        {
            stateMachine = GetComponent<ScriptableStateMachine>();
        }
    }
}