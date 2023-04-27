using System;
using System.Linq;

namespace BehaviourTrees
{
    public static class BehaviourTreeUtils
    {
        public static IBTNode Create(JsonBehaviourTreeNode node)
        {
            if (node.TypeName == typeof(RepeatBTNode).AssemblyQualifiedName)
            {
                return new RepeatBTNode
                {
                    Impl = Create(node.Args[0])
                };
            }

            if (node.TypeName == typeof(SequenceBTNode).AssemblyQualifiedName)
            {
                return new SequenceBTNode
                {
                    Nodes = (node.Args ?? Array.Empty<JsonBehaviourTreeNode>()).Select(Create).ToArray()
                };
            }

            if (node.TypeName == typeof(ParallelBTNode).AssemblyQualifiedName)
            {
                return new ParallelBTNode
                {
                    Nodes = (node.Args ?? Array.Empty<JsonBehaviourTreeNode>()).Select(Create).ToArray()
                };
            }

            return (IBTNode)Activator.CreateInstance(Type.GetType(node.TypeName) ??
                                                     throw new NullReferenceException(node.TypeName));
        }
    }
}