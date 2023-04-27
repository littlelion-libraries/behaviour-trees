namespace BehaviourTrees
{
    public interface IBTNode
    {
        IBehaviourTreeAdapter Adapter { set; }
        bool Step();
    }
}