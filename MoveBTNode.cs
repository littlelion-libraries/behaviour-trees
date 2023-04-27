namespace BehaviourTrees
{
    public class MoveBTNode : IBTNode
    {
        private IBehaviourTreeAdapter _adapter;

        public IBehaviourTreeAdapter Adapter
        {
            set => _adapter = value;
        }

        public bool Step()
        {
            if (!_adapter.CanMove()) return false;
            _adapter.Move();
            return true;
        }
    }
}