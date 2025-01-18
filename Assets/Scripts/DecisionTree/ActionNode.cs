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
            //TODO：具体的行为
        }
    }

    public class CookingAction : ActionNode
    {
        public override void HandlerAction()
        {
            Debug.Log("做饭。。。");
        }
    }

    public class OrderTakeOutsAction : ActionNode
    {
        public override void HandlerAction()
        {
            Debug.Log("点外卖");
        }
    }

    public class ProgrameAction : ActionNode
    {
        public override void HandlerAction()
        {
            Debug.Log("敲代码");
        }
    }

    public class PlayPhoneAction : ActionNode
    {
        public override void HandlerAction()
        {
            Debug.Log("玩儿手机");
        }
    }
}





