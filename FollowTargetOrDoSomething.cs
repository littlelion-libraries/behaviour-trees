using UnityEngine;
using UnityEngine.Events;

namespace BehaviourTrees
{
    public class FollowTargetOrDoSomething : MonoBehaviour, IBehaviourTree
    {
        [SerializeField] private UnityEvent step;
        private IBehaviourTreeAdapter _adapter;

        public IBehaviourTreeAdapter Adapter
        {
            set => _adapter = value;
        }

        public void Step()
        {
            if (_adapter.HasTargetInRange())
            {
                _adapter.FollowTarget();
                return;
            }

            _adapter.FindTargetInRange();
            step.Invoke();
        }
    }
}