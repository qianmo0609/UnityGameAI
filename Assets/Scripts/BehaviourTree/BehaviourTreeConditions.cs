
using UnityEngine;

namespace BehaviourTrees
{
    public class BehaviourTreeConditions : BehaviourTreeNode
    {
        protected virtual bool check()
        {
            return true;
        }
    }

    public class AnimatorIsEnabled : BehaviourTreeConditions
    {
        Animator ani;
        public AnimatorIsEnabled(Animator animator)
        {
            this.ani = animator;
        }

        protected override bool check()
        {
            return this.ani.enabled;
        }

        public override Status Process()
        {
            return this.check() ? Status.SUCCESS : Status.FAILURE;
        }
    }


    public class InBed : BehaviourTreeConditions
    {
        Player player;
        public InBed(Player player)
        {
            this.player = player;
        }

        protected override bool check()
        {
            return this.player.isInBed;
        }

        public override Status Process()
        {
            return this.check() ? Status.SUCCESS : Status.FAILURE;
        }
    }

}

