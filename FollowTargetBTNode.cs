namespace BehaviourTrees
{
    public class FollowTargetBTNode : IBTNode
    {
        private IBehaviourTreeAdapter _adapter;

        public IBehaviourTreeAdapter Adapter
        {
            set => _adapter = value;
        }

        public bool Step()
        {
            if (_adapter.HasTargetInRange())
            {
                _adapter.FollowTarget();
                return true;
            }

            _adapter.FindTargetInRange();
            return false;
        }
    }
}