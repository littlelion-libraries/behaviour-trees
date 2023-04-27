using System;
using CSharpBoosts;

namespace BehaviourTrees
{
    public class FollowTargetBTNode : IBTNode
    {
        // private IBehaviourTreeAdapter _adapter;
        //
        // public IBehaviourTreeAdapter Adapter
        // {
        //     set => _adapter = value;
        // }
        private Action _findTargetInRange;
        private Action _followTarget;
        private Func<bool> _hasTargetInRange;

        public IDynamicObject Object
        {
            set
            {
                _findTargetInRange = value.FindTargetInRange();
                _followTarget = value.FollowTarget();
                _hasTargetInRange = value.HasTargetInRange();
            }
        }

        public bool Step()
        {
            // if (_adapter.HasTargetInRange())
            // {
            //     _adapter.FollowTarget();
            //     return true;
            // }
            //
            // _adapter.FindTargetInRange();
            if (_hasTargetInRange())
            {
                _followTarget();
                return true;
            }

            _findTargetInRange();
            return false;
        }
    }
}