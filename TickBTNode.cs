using System;
using CSharpBoosts;

namespace BehaviourTrees
{
    public class TickBTNode : IBTNode
    {
        private IBTNode _impl;

        // public IBehaviourTreeAdapter Adapter
        // {
        //     set => _impl.Adapter = value;
        // }

        public bool Expanded { get; set; }

        public IBTNode Impl
        {
            get => _impl;
            set => _impl = value;
        }

        public int Tick { get; private set; }

        public IDynamicObject Object
        {
            set => _impl.Object = value;
        }

        public bool Step()
        {
            Tick = (int)DateTime.Now.Ticks;
            return _impl.Step();
        }
    }
}