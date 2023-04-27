using BehaviourTrees.Customs;

namespace BehaviourTrees
{
    public class MoveBTNode : IfBTNode
    {
        public MoveBTNode()
        {
            Child = BtNodeUtility.Move();
            Hash = ObjectMethod.CanMove;
        }
    }
}