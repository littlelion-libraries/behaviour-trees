using System.Linq;
using CSharpBoosts;

namespace BehaviourTrees
{
    public class ParallelBTNode : IBTNode
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

        public IBTNode[] Nodes
        {
            get => _nodes;
            set => _nodes = value;
        }

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

        public bool Step()
        {
            return _nodes.All(it => it.Step());
        }
    }
}