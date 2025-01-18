using System.Collections.Generic;
using UnityEngine;

namespace DecisionTree
{
    public class MultiDecisionNode : DecisionTreeNode
    {
        private int m_Index;
        private List<DecisionTreeNode> subNodes;

        private MultiDecisionNode(List<DecisionTreeNode> nodes)
        {
            this.subNodes = nodes;
        }

        public void setIdx(int idx)
        {
            this.m_Index = idx;
        }

        private DecisionTreeNode getBranch()
        {
            return subNodes[this.m_Index];
        }

        public override DecisionTreeNode makeDecision()
        {
            return this.getBranch().makeDecision();
        }
    }

    public class Decision : DecisionTreeNode
    {
        protected DecisionTreeNode trueNode;
        protected DecisionTreeNode falseNode;

        public Decision(DecisionTreeNode trueNode, DecisionTreeNode falseNode)
        {
            this.trueNode = trueNode;
            this.falseNode = falseNode;
        }

        public override DecisionTreeNode makeDecision()
        {
            return this.getBranch().makeDecision();
        }

        protected virtual DecisionTreeNode getBranch()
        {
            return this;
        }
    }

    public class BoolDecisionNode : Decision
    {
        private bool curValue;

        public BoolDecisionNode(DecisionTreeNode trueNode, DecisionTreeNode falseNode) : base(trueNode, falseNode)
        {
        }

        public void setCurValue(bool value)
        {
            this.curValue = value;
        }

        protected override DecisionTreeNode getBranch()
        {
            return this.curValue ? trueNode : falseNode;
        }
    }

    public class FloatDecisionNode : Decision
    {
        private float maxValue;
        private float minValue;
        private float curValue;

        public FloatDecisionNode(float maxValue, float minValue, DecisionTreeNode trueNode, DecisionTreeNode falseNode) : base(trueNode, falseNode)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public void setCurValue(float value)
        {
            this.curValue = value;
        }

        protected override DecisionTreeNode getBranch()
        {
            return this.curValue <= this.maxValue && this.curValue >= this.minValue ? trueNode : falseNode;
        }
    }

    public class EnumDecisionNode : Decision
    {
        private int enumValue;
        private int curValue;

        public EnumDecisionNode(int enumValue, DecisionTreeNode trueNode, DecisionTreeNode falseNode) : base(trueNode, falseNode)
        {
            this.enumValue = enumValue;
        }

        public void setCurValue(int value)
        {
            this.curValue = value;
        }

        protected override DecisionTreeNode getBranch()
        {
            return this.curValue == this.enumValue ? trueNode : falseNode;
        }
    }

    public class VectorDecisionNode : Decision
    {
        private Vector3 vectorValue;
        private Vector3 curValue;
        private float distance;

        public VectorDecisionNode(Vector3 value, float distance, DecisionTreeNode trueNode, DecisionTreeNode falseNode) : base(trueNode, falseNode)
        {
            this.vectorValue = value;
            this.distance = distance;
        }

        public void setCurValue(Vector3 v)
        {
            this.curValue = v;
        }

        protected override DecisionTreeNode getBranch()
        {
            return this.HandlerVector();
        }

        private DecisionTreeNode HandlerVector()
        {
            if (Vector3.Distance(this.curValue, this.vectorValue) < this.distance)
            {
                return trueNode;
            }
            return falseNode;
        }
    }

    public class EnergeDecisionNode : FloatDecisionNode
    {
        Player m_player;
        public EnergeDecisionNode(Player player, float maxValue, float minValue, DecisionTreeNode trueNode, DecisionTreeNode falseNode) : base(maxValue, minValue, trueNode, falseNode)
        {
            this.m_player = player;
        }

        public override DecisionTreeNode makeDecision()
        {
            this.setCurValue(this.m_player.m_energeValue);
            return base.makeDecision();
        }
    }

    public class HungryDecisionNode : FloatDecisionNode
    {
        Player m_player;
        public HungryDecisionNode(Player player, float maxValue, float minValue, DecisionTreeNode trueNode, DecisionTreeNode falseNode) : base(maxValue, minValue, trueNode, falseNode)
        {
            this.m_player = player;
        }

        public override DecisionTreeNode makeDecision()
        {
            this.setCurValue(this.m_player.m_hungryValue);
            return base.makeDecision();
        }
    }

    public class IsGoodHumor : BoolDecisionNode
    {
        Player m_player;

        public IsGoodHumor(Player player, DecisionTreeNode trueNode, DecisionTreeNode falseNode) : base(trueNode, falseNode)
        {
            this.m_player = player;
        }

        public override DecisionTreeNode makeDecision()
        {
            this.setCurValue(this.m_player.m_isGoodHumor);
            return base.makeDecision();
        }
    }
}

