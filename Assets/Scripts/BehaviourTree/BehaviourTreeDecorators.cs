using Unity.VisualScripting;

namespace BehaviourTrees
{
    public class BehaviourTreeDecorators : BehaviourTreeNode
    {
    }

    public class Inverter : BehaviourTreeDecorators
    {
        public override Status Process()
        {
            Status childstatus = children[0].Process();
            if (childstatus == Status.RUNNING) return Status.RUNNING;
            if (childstatus == Status.FAILURE)
                return Status.SUCCESS;
            else
                return Status.FAILURE;

        }
    }

    public class While : BehaviourTreeDecorators
    {
        BehaviourTreeNode dependancy; 
       
        public While(BehaviourTreeNode dependancy)
        {
            this.dependancy = dependancy;
        }

        public override Status Process()
        {

            if (dependancy.Process() == Status.FAILURE)
            {

                return Status.SUCCESS;
            }

            Status childstatus = children[currentChild].Process();
            if (childstatus == Status.RUNNING) return Status.RUNNING;
            if (childstatus == Status.FAILURE) return childstatus;

            currentChild++;
            if (currentChild >= children.Count)
            {

                currentChild = 0;
            }

            return Status.RUNNING;
        }
    }
}
