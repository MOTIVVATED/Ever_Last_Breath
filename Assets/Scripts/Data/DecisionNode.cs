using System;
using System.Collections.Generic;

[Serializable]
public class DecisionNode
{
    public string id;
    public string text;
    public List<DecisionOption> options;
}
