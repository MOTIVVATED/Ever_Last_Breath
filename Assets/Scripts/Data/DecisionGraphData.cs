using System;
using System.Collections.Generic;

[Serializable]
public class DecisionGraphData
{
    public string startNode;
    public List<DecisionNode> nodes;
    public List<EndingData> endings;
}
