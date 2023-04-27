using System;
using CSharpBoosts;

namespace BehaviourTrees
{
    public class ChangeDirectionBTNode : IBTNode
    {
        // private IBehaviourTreeAdapter _adapter;
        //
        // public IBehaviourTreeAdapter Adapter
        // {
        //     set => _adapter = value;
        // }
        private Action _changeDirection;

        public IDynamicObject Object
        {
            set => _changeDirection = value.ChangeDirection();
        }

        public bool Step()
        {
            _changeDirection();
            return true;
        }
    }
}