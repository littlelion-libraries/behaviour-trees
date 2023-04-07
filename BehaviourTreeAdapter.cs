using System;

namespace BehaviourTrees
{
    public class BehaviourTreeAdapter : IBehaviourTreeAdapter
    {
        private Func<bool> _canMove;
        private Action _changeDirection;
        private Action _followTarget;
        private Func<bool> _hasTargetInRange;
        private Action _move;

        public Func<bool> CanMove
        {
            set => _canMove = value;
        }

        public Action ChangeDirection
        {
            set => _changeDirection = value;
        }

        public Action FollowTarget
        {
            set => _followTarget = value;
        }

        public Func<bool> HasTargetInRange
        {
            set => _hasTargetInRange = value;
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

        void IBehaviourTreeAdapter.FollowTarget()
        {
            _followTarget();
        }

        bool IBehaviourTreeAdapter.HasTargetInRange()
        {
            return _hasTargetInRange();
        }

        void IBehaviourTreeAdapter.Move()
        {
            _move();
        }
    }
}