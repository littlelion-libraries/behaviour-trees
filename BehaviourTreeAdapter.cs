using System;

namespace BehaviourTrees
{
    public class BehaviourTreeAdapter : IBehaviourTreeAdapter
    {
        private Func<bool> _canMove;
        private Action _changeDirection;
        private Action _move;

        public Func<bool> CanMove
        {
            set => _canMove = value;
        }

        public Action ChangeDirection
        {
            set => _changeDirection = value;
        }

        public Action Move
        {
            set => _move = value;
        }

        bool IBehaviourTreeAdapter.CanMove()
        {
            return _canMove();
        }

        void IBehaviourTreeAdapter.ChangeDirection()
        {
            _changeDirection();
        }

        void IBehaviourTreeAdapter.Move()
        {
            _move();
        }
    }
}