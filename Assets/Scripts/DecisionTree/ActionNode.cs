using UnityEngine;

namespace DecisionTree
{
    public class ActionNode : DecisionTreeNode
    {
        public override DecisionTreeNode makeDecision()
        {
            return this;
        }

        public virtual void HandlerAction()
        {
            //TODO���������Ϊ
        }
    }

    public class CookingAction : ActionNode
    {
        public override void HandlerAction()
        {
            Debug.Log("����������");
        }
    }

    public class OrderTakeOutsAction : ActionNode
    {
        public override void HandlerAction()
        {
            Debug.Log("������");
        }
    }

    public class ProgrameAction : ActionNode
    {
        public override void HandlerAction()
        {
            Debug.Log("�ô���");
        }
    }

    public class PlayPhoneAction : ActionNode
    {
        public override void HandlerAction()
        {
            Debug.Log("����ֻ�");
        }
    }
}





