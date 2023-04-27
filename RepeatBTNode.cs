namespace BehaviourTrees
{
    public class RepeatBTNode : IBTNode
    {
        private IBTNode _impl;

        public IBehaviourTreeAdapter Adapter
        {
            set => _impl.Adapter = value;
        }

        public IBTNode Impl
        {
            get => _impl;
            set => _impl = value;
        }

        public bool Step()
        {
            _impl.Step();
            return true;
        }
    }
}