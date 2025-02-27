using GD.Types;
using System.Collections.Generic;
using System.Linq;

namespace GD.Predicates
{
    public class CompositePredicate : IPredicate
    {
        public LogicType logicType;
        public List<IPredicate> predicates;

        public bool Evaluate()
        {
            if (predicates == null || predicates.Count == 0) return false;

            return logicType switch
            {
                LogicType.AND => predicates.All(p => p.Evaluate()),
                LogicType.OR => predicates.Any(p => p.Evaluate()),
                LogicType.XOR => predicates.Count(p => p.Evaluate()) == 1,
                _ => false
            };
        }
    }
}