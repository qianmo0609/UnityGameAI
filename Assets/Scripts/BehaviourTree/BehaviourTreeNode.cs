
using System.Collections.Generic;

namespace BehaviourTrees
{
    public class BehaviourTreeNode
    {
        public enum Status { SUCCESS, RUNNING, FAILURE };
        public Status status;
        public List<BehaviourTreeNode> children = new List<BehaviourTreeNode>();
        public int currentChild = 0;
        public string name;
        public int sortOrder;

        public virtual Status Process()
        {
            return children[currentChild].Process();
        }

        public void AddChild(BehaviourTreeNode n)
        {
            children.Add(n);
        }
    }
}


