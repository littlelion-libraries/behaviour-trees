using CSharpBoosts;

namespace BehaviourTrees
{
    public interface IBTNode
    {
        // IBehaviourTreeAdapter Adapter { set; }
        IDynamicObject Object { set; }
        bool Step();
    }
}