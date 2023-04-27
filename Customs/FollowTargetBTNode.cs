namespace BehaviourTrees.Customs
{
    public class FollowTargetBTNode : SequenceBTNode
    {
        public FollowTargetBTNode()
        {
            Nodes = BtNodeUtility.FollowTarget();
        }
    }
}