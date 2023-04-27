using System;
using CSharpBoosts;

namespace BehaviourTrees
{
    public class IfBTNode : IBTNode
    {
        private IBTNode _child;
        private Func<bool> _condition;
        private string _hash;

        public string Hash
        {
            set => _hash = value;
        }

        public IBTNode Child
        {
            set => _child = value;
        }

        public IDynamicObject Object
        {
            set
            {
                _condition = value.GetValue<Func<bool>>(_hash);
                _child.Object = value;
            }
        }

        public bool Step()
        {
            return _condition() && _child.Step();
        }
    }
}