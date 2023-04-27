using BehaviourTrees.Customs;

namespace BehaviourTrees
{
    public static class BtNodeUtility
    {
        public static string ChangeDirection()
        {
            return ObjectMethod.ChangeDirection;
        }
        
        public static IBTNode[] FollowTarget()
        {
            return new IBTNode[]
            {
                new IfBTNode
                {
                    Child = new ActionBTNode
                    {
                        Hash = ObjectMethod.FollowTarget
                    },
                    Hash = ObjectMethod.HasTargetInRange
                },
                new ActionBTNode
                {
                    Hash = ObjectMethod.FindTargetInRange
                }
            };
        }
        
        public static IBTNode Move()
        {
            return new ActionBTNode
            {
                Hash = ObjectMethod.Move
            };
        }
    }
}