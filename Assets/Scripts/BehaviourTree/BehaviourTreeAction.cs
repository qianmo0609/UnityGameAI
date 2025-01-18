
using UnityEngine;

namespace BehaviourTrees
{
    public class BehaviourTreeAction : BehaviourTreeNode
    {
        public override Status Process()
        {
            return Status.SUCCESS;
        }
    }

    public class Cooking : BehaviourTreeAction
    {
        public override Status Process()
        {
            Debug.Log("做饭。。。");
            return Status.SUCCESS;
        }
    }

    public class Dining : BehaviourTreeAction
    {
        public override Status Process()
        {
            Debug.Log("吃饭。。。");
            return Status.SUCCESS;
        }
    }

    public class Washing : BehaviourTreeAction
    {
        public override Status Process()
        {
            Debug.Log("洗衣服。。。");
            return Status.SUCCESS;
        }
    }

    public class Clean : BehaviourTreeAction
    {
        public override Status Process()
        {
            Debug.Log("拖地。。。");
            return Status.SUCCESS;
        }
    }

    public class PlayingIphone : BehaviourTreeAction
    {
        public override Status Process()
        {
            Debug.Log("玩手机。。。");
            return Status.SUCCESS;
        }
    }
}


