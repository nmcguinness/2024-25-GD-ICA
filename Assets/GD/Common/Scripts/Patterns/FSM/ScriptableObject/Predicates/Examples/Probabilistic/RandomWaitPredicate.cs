using System.Collections.Generic;
using UnityEngine;

namespace GD.FSM.SO
{
    //EXERCISE
    [CreateAssetMenu(fileName = "RandomWaitPredicate",
        menuName = "GD/FSM/Scriptable/Predicate/Probabilistic/Wait N Seconds")]
    public class RandomWaitPredicate : ScriptablePredicate
    {
        [SerializeField]
        private float min = 1;

        [SerializeField]
        private float max = 5;

        private class WaitData
        {
            public float startTime;
            public float waitDuration;
        }

        private Dictionary<ScriptableStateController, WaitData> waitDataPerController
            = new Dictionary<ScriptableStateController, WaitData>();

        public override bool Evaluate(ScriptableStateController controller)
        {
            if (!waitDataPerController.TryGetValue(controller, out WaitData data))
            {
                data = new WaitData
                {
                    waitDuration = Random.Range(min, max),
                    startTime = Time.time
                };
                waitDataPerController[controller] = data;
            }

            return (Time.time - data.startTime) >= data.waitDuration;
        }
    }
}