using System;

namespace GD.FSM
{
    public class FuncPredicate : IPredicate
    {
        private Func<bool> func;

        public FuncPredicate(Func<bool> func) => this.func = func;

        public bool Evaluate() => func();
    }
}