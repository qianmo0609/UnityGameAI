
namespace BehaviourTrees
{
    public class BehaviourTree:BehaviourTreeNode
    {
        public override Status Process()
        {
            if (children.Count == 0) return Status.SUCCESS;
            return children[currentChild].Process();
        }
    }
}


