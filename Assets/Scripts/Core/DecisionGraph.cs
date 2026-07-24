using System.Collections.Generic;

public class DecisionGraph
{
    private readonly Dictionary<string, DecisionNode> nodesById = new Dictionary<string, DecisionNode>();

    public string StartNode { get; }

    public DecisionGraph(DecisionGraphData data)
    {
        StartNode = data.startNode;

        foreach (var node in data.nodes)
        {
            nodesById[node.id] = node;
        }
    }

    public DecisionNode GetNode(string id)
    {
        return nodesById.TryGetValue(id, out var node) ? node : null;
    }
}
