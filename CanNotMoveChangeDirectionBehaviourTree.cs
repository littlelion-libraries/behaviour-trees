using UnityEngine;

namespace BehaviourTrees
{
    public class CanNotMoveChangeDirectionBehaviourTree : MonoBehaviour, IBehaviourTree
    {
        private IBehaviourTreeAdapter _adapter;

        public IBehaviourTreeAdapter Adapter
        {
            set => _adapter = value;
        }

        public void Step()
        {
            if (_adapter.CanMove())
            {
                _adapter.Move();
                return;
            }

            _adapter.ChangeDirection();
        }
    }
}