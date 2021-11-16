using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public abstract Node Decide();
}

public class ActionNode : Node
{
    string name;

    public override Node Decide()
    {
        return this;
    }
}
