
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
            Debug.Log("����������");
            return Status.SUCCESS;
        }
    }

    public class Dining : BehaviourTreeAction
    {
        public override Status Process()
        {
            Debug.Log("�Է�������");
            return Status.SUCCESS;
        }
    }

    public class Washing : BehaviourTreeAction
    {
        public override Status Process()
        {
            Debug.Log("ϴ�·�������");
            return Status.SUCCESS;
        }
    }

    public class Clean : BehaviourTreeAction
    {
        public override Status Process()
        {
            Debug.Log("�ϵء�����");
            return Status.SUCCESS;
        }
    }

    public class PlayingIphone : BehaviourTreeAction
    {
        public override Status Process()
        {
            Debug.Log("���ֻ�������");
            return Status.SUCCESS;
        }
    }
}


