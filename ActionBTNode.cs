using System;
using CSharpBoosts;

namespace BehaviourTrees
{
    public class ActionBTNode : IBTNode
    {
        private Action _action;
        private string _hash;

        public string Hash
        {
            get => _hash;
            set => _hash = value;
        }

        public IDynamicObject Object
        {
            set => _action = value.GetValue<Action>(_hash);
        }

        public bool Step()
        {
            _action();
            return true;
        }
    }
}