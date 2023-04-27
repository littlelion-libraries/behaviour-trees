using System;

namespace BehaviourTrees
{
    [Serializable]
    public class BehaviourTreeNode
    {
        public BehaviourTreeNode[] args;
        public string guid;
        public string typeName;
    }
}