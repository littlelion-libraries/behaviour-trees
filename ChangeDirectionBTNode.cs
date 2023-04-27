namespace BehaviourTrees
{
    public class ChangeDirectionBTNode : IBTNode
    {
        private IBehaviourTreeAdapter _adapter;

        public IBehaviourTreeAdapter Adapter
        {
            set => _adapter = value;
        }

        public bool Step()
        {
            _adapter.ChangeDirection();
            return true;
        }
    }
}