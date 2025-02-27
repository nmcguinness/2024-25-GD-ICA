using GD.Types;
using System;

namespace GD.FSM.SO
{
    [Serializable]
    public abstract class ScriptablePredicate : ScriptableGameObject
    {
        public abstract bool Evaluate(ScriptableStateController controller);
    }
}