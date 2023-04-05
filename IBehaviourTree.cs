namespace BehaviourTrees
{
    public interface IBehaviourTree
    {
        IBehaviourTreeAdapter Adapter { set; }
        void Step();
    }
}