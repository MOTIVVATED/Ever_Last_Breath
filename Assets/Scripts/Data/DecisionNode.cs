using System;
using System.Collections.Generic;

[Serializable]
public class DecisionNode
{
    public string id;
    public string text;
    public string heroState;
    public List<DecisionOption> options;
}
