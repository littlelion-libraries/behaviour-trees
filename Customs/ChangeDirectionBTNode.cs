namespace BehaviourTrees.Customs
{
    public class ChangeDirectionBTNode : ActionBTNode
    {
        public ChangeDirectionBTNode()
        {
            Hash = BtNodeUtility.ChangeDirection();
        }
    }
}