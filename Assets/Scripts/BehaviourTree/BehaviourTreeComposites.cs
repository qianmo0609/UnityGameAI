
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    public class BehaviourTreeComposites : BehaviourTreeNode
    {

    }

    public class Selector : BehaviourTreeComposites
    {
        public override Status Process()
        {
            Status childstatus = children[currentChild].Process();
            if (childstatus == Status.RUNNING) return Status.RUNNING;

            if (childstatus == Status.SUCCESS)
            {
                currentChild = 0;
                return Status.SUCCESS;
            }

            currentChild++;
            if (currentChild >= children.Count)
            {
                currentChild = 0;
                return Status.FAILURE;
            }

            return Status.RUNNING;
        }
    }

    public class Sequence : BehaviourTreeComposites
    {
        public override Status Process()
        {
            Status childstatus = children[currentChild].Process();
            if (childstatus == Status.RUNNING) return Status.RUNNING;
            if (childstatus == Status.FAILURE)
                return childstatus;

            currentChild++;
            if (currentChild >= children.Count)
            {
                currentChild = 0;
                return Status.SUCCESS;
            }

            return Status.RUNNING;
        }
    }

    public class PrioritySelectorNode : BehaviourTreeComposites
    {
        BehaviourTreeNode[] nodeArray;
        bool ordered = false;

        void OrderNodes()
        {
            nodeArray = children.ToArray();
            Sort(nodeArray, 0, children.Count - 1);
            children = new List<BehaviourTreeNode>(nodeArray);
        }

        public override Status Process()
        {
            if (!ordered)
            {
                OrderNodes();
                ordered = true;
            }

            Status childstatus = children[currentChild].Process();
            if (childstatus == Status.RUNNING) return Status.RUNNING;

            if (childstatus == Status.SUCCESS)
            {
                currentChild = 0;
                ordered = false;
                return Status.SUCCESS;
            }

            currentChild++;
            if (currentChild >= children.Count)
            {

                currentChild = 0;
                ordered = false;
                return Status.FAILURE;
            }

            return Status.RUNNING;
        }

        //QuickSort
        //Adapted from: https://exceptionnotfound.net/quick-sort-csharp-the-sorting-algorithm-family-reunion/
        int Partition(BehaviourTreeNode[] array, int low,
                                    int high)
        {
            BehaviourTreeNode pivot = array[high];

            int lowIndex = (low - 1);

            //2. Reorder the collection.
            for (int j = low; j < high; j++)
            {
                if (array[j].sortOrder <= pivot.sortOrder)
                {
                    lowIndex++;

                    BehaviourTreeNode temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            BehaviourTreeNode temp1 = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = temp1;

            return lowIndex + 1;
        }

        void Sort(BehaviourTreeNode[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);
                Sort(array, low, partitionIndex - 1);
                Sort(array, partitionIndex + 1, high);
            }
        }
    }

    public class RandomSelector : BehaviourTreeComposites
    {
        bool shuffled = false;

        public override Status Process()
        {
            if (!shuffled)
            {
                children.Shuffle();
                shuffled = true;
            }

            Status childstatus = children[currentChild].Process();
            if (childstatus == Status.RUNNING) return Status.RUNNING;

            if (childstatus == Status.SUCCESS)
            {
                currentChild = 0;
                shuffled = false;
                return Status.SUCCESS;
            }

            currentChild++;
            if (currentChild >= children.Count)
            {
                currentChild = 0;
                shuffled = false;
                return Status.FAILURE;
            }

            return Status.RUNNING;
        }
    }
}

