using System;
using System.Linq;

namespace BehaviourTrees
{
    public static class TickBtNodeUtils
    {
        public static TickBTNode Create(JsonBehaviourTreeNode node)
        {
            if (node.TypeName == typeof(RepeatBTNode).AssemblyQualifiedName)
            {
                return new TickBTNode
                {
                    Impl = new RepeatBTNode
                    {
                        Impl = Create(node.Args[0])
                    }
                };
            }

            if (node.TypeName == typeof(SequenceBTNode).AssemblyQualifiedName)
            {
                return new TickBTNode
                {
                    Impl = new SequenceBTNode
                    {
                        Nodes = (node.Args ?? Array.Empty<JsonBehaviourTreeNode>()).Select(it => Create(it) as IBTNode)
                            .ToArray()
                    }
                };
            }

            if (node.TypeName == typeof(ParallelBTNode).AssemblyQualifiedName)
            {
                return new TickBTNode
                {
                    Impl = new ParallelBTNode
                    {
                        Nodes = (node.Args ?? Array.Empty<JsonBehaviourTreeNode>()).Select(it => Create(it) as IBTNode)
                            .ToArray()
                    }
                };
            }

            return new TickBTNode
            {
                Impl = (IBTNode)Activator.CreateInstance(Type.GetType(node.TypeName) ??
                                                         throw new NullReferenceException(node.TypeName))
            };
        }
    }
}