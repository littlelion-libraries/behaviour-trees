namespace BehaviourTrees.Customs
{
    public class FollowTargetMoveChangeDirectionBtNode : SequenceBTNode
    {
        public FollowTargetMoveChangeDirectionBtNode()
        {
            Nodes = new IBTNode[]
            {
                new SequenceBTNode
                {
                    Nodes = BtNodeUtility.FollowTarget()
                },
                new IfBTNode
                {
                    Child = BtNodeUtility.Move(),
                    Hash = ObjectMethod.CanMove
                },
                new ActionBTNode
                {
                    Hash = BtNodeUtility.ChangeDirection()
                }
            };
        }
    }
}