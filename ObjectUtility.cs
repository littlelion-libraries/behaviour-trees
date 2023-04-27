using System;
using CSharpBoosts;

namespace BehaviourTrees
{
    public static class ObjectUtility
    {
        public static Func<bool> CanMove(this IDynamicObject obj)
        {
            return obj.GetValue<Func<bool>>(ObjectMethod.CanMove);
        }
        
        public static Action ChangeDirection(this IDynamicObject obj)
        {
            return obj.GetValue<Action>(ObjectMethod.ChangeDirection);
        }

        public static Action FindTargetInRange(this IDynamicObject obj)
        {
            return obj.GetValue<Action>(ObjectMethod.FindTargetInRange);
        }

        public static Action FollowTarget(this IDynamicObject obj)
        {
            return obj.GetValue<Action>(ObjectMethod.FollowTarget);
        }

        public static Func<bool> HasTargetInRange(this IDynamicObject obj)
        {
            return obj.GetValue<Func<bool>>(ObjectMethod.HasTargetInRange);
        }

        public static Action Move(this IDynamicObject obj)
        {
            return obj.GetValue<Action>(ObjectMethod.Move);
        }
    }
}