namespace BehaviourTrees
{
    public interface IBehaviourTreeAdapter
    {
        bool CanMove();
        void ChangeDirection();
        void Move();
    }
}