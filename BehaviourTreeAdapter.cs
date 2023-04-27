// using System;
//
// namespace BehaviourTrees
// {
//     public class BehaviourTreeAdapter : IBehaviourTreeAdapter
//     {
//         private Func<bool> _canMove;
//         private Action _changeDirection;
//         private Action _findTargetInRange;
//         private Action _followTarget;
//         private Func<bool> _hasTargetInRange;
//         private Action _move;
//         private Func<bool> _tryFindTargetInRange;
//
//         public Func<bool> CanMove
//         {
//             set => _canMove = value;
//         }
//
//         public Action ChangeDirection
//         {
//             set => _changeDirection = value;
//         }
//
//         public Action FindTargetInRange
//         {
//             set => _findTargetInRange = value;
//         }
//
//         public Action FollowTarget
//         {
//             set => _followTarget = value;
//         }
//
//         public Func<bool> HasTargetInRange
//         {
//             set => _hasTargetInRange = value;
//         }
//
//         public Action Move
//         {
//             set => _move = value;
//         }
//
//         public Func<bool> TryFindTargetInRange
//         {
//             set => _tryFindTargetInRange = value;
//         }
//
//         bool IBehaviourTreeAdapter.CanMove()
//         {
//             return _canMove();
//         }
//
//         void IBehaviourTreeAdapter.ChangeDirection()
//         {
//             _changeDirection();
//         }
//
//         void IBehaviourTreeAdapter.FindTargetInRange()
//         {
//             _findTargetInRange();
//         }
//
//         void IBehaviourTreeAdapter.FollowTarget()
//         {
//             _followTarget();
//         }
//
//         bool IBehaviourTreeAdapter.HasTargetInRange()
//         {
//             return _hasTargetInRange();
//         }
//
//         void IBehaviourTreeAdapter.Move()
//         {
//             _move();
//         }
//
//         bool IBehaviourTreeAdapter.TryFindTargetInRange()
//         {
//             return _tryFindTargetInRange();
//         }
//     }
// }