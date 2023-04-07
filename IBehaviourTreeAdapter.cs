namespace BehaviourTrees
{
    public interface IBehaviourTreeAdapter
    {
        bool CanMove();
        void ChangeDirection();
        void FollowTarget();
        bool HasTargetInRange();
        void Move();
    }
}