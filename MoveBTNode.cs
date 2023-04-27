using System;
using CSharpBoosts;

namespace BehaviourTrees
{
    public class MoveBTNode : IBTNode
    {
        // private IBehaviourTreeAdapter _adapter;
        //
        // public IBehaviourTreeAdapter Adapter
        // {
        //     set => _adapter = value;
        // }
        private Func<bool> _canMove;
        private Action _move;

        public IDynamicObject Object
        {
            set
            {
                _canMove = value.CanMove();
                _move = value.Move();
            }
        }

        public bool Step()
        {
            // if (!_adapter.CanMove())
            // return false;
            // _adapter.Move();
            if (!_canMove()) return false;
            _move();
            return true;
        }
    }
}