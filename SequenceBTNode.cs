using CSharpBoosts;

namespace BehaviourTrees
{
    public class SequenceBTNode : IBTNode
    {
        private IBTNode[] _nodes;

        // public IBehaviourTreeAdapter Adapter
        // {
        //     set
        //     {
        //         foreach (var node in _nodes)
        //         {
        //             node.Adapter = value;
        //         }
        //     }
        // }

        public IDynamicObject Object
        {
            set
            {
                foreach (var node in _nodes)
                {
                    node.Object = value;
                }
            }
        }

        public IBTNode[] Nodes
        {
            get => _nodes;
            set => _nodes = value;
        }

        public bool Step()
        {
            foreach (var node in _nodes)
            {
                if (node.Step()) return true;
            }

            return false;
        }
    }
}