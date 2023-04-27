using System.Linq;

namespace BehaviourTrees
{
    public static class TickBtNodeUtils
    {
        public static TickBTNode Add(IBTNode node)
        {
            if (node is RepeatBTNode repeatBtNode)
            {
                repeatBtNode.Impl = Add(repeatBtNode.Impl);
                return new TickBTNode
                {
                    Impl = repeatBtNode
                };
            }

            if (node is SequenceBTNode sequenceBtNode)
            {
                sequenceBtNode.Nodes = sequenceBtNode.Nodes.Select(it => Add(it) as IBTNode).ToArray();
                return new TickBTNode
                {
                    Impl = sequenceBtNode
                };
            }

            if (node is ParallelBTNode parallelBtNode)
            {
                parallelBtNode.Nodes = parallelBtNode.Nodes.Select(it => Add(it) as IBTNode).ToArray();
                return new TickBTNode
                {
                    Impl = parallelBtNode
                };
            }

            return new TickBTNode
            {
                Impl = node
            };
        }
    }
}