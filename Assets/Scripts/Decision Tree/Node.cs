using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public abstract Node Decide();
}


public class ActionNode : Node
{
    public string name;

    public ActionNode(string name)
    {
        this.name = name;
    }

    public override Node Decide()
    {
        return this;
    }
}


public abstract class DecisionNode : Node
{
    public abstract Node GetBranch();

    public override Node Decide()
    {
        return GetBranch().Decide();
    }
}


public abstract class BinaryDecisionNode : DecisionNode
{
    public Node yesNode;
    public Node noNode;

    public override Node GetBranch()
    {
        if (Evaluate())
        {
            return yesNode;
        }
        else
        {
            return noNode;
        }
    }

    public abstract bool Evaluate();
}


public class BoolDecision : BinaryDecisionNode
{
    bool testValue;

    public override bool Evaluate()
    {
        return testValue;
    }
}



public class DoubleDecision : BinaryDecisionNode
{
    double minValue;
    double maxValue;
    double testValue;

    public override bool Evaluate()
    {
        return maxValue >= testValue && testValue >= minValue;
    }
}



public class ObjectDecision : BinaryDecisionNode
{
    Evaluator evaluator;

    public ObjectDecision(Evaluator evaluator)
    {
        this.evaluator = evaluator;
    }

    public override bool Evaluate()
    {
        return evaluator.Evaluate();
    }
}