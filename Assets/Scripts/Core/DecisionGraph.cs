using System.Collections.Generic;

public class DecisionGraph
{
    private readonly Dictionary<string, DecisionNode> nodesById = new Dictionary<string, DecisionNode>();
    private readonly Dictionary<string, string> endingTextsById = new Dictionary<string, string>();
    private readonly Dictionary<string, string> endingHeroStatesById = new Dictionary<string, string>();

    public string StartNode { get; }

    public DecisionGraph(DecisionGraphData data)
    {
        StartNode = data.startNode;

        foreach (var node in data.nodes)
        {
            nodesById[node.id] = node;
        }

        foreach (var ending in data.endings)
        {
            endingTextsById[ending.id] = ending.text;
            endingHeroStatesById[ending.id] = ending.heroState;
        }
    }

    public DecisionNode GetNode(string id)
    {
        return nodesById.TryGetValue(id, out var node) ? node : null;
    }

    public string GetEndingText(string endingId)
    {
        return endingTextsById.TryGetValue(endingId, out var text) ? text : endingId;
    }

    public string GetEndingHeroState(string endingId)
    {
        return endingHeroStatesById.TryGetValue(endingId, out var state) ? state : "Basic";
    }
}
