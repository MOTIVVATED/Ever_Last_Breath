using UnityEngine;

public class DecisionGraphLoader : MonoBehaviour
{
    public TextAsset graphJson;

    public DecisionGraph Graph { get; private set; }

    private void Awake()
    {
        var data = JsonUtility.FromJson<DecisionGraphData>(graphJson.text);
        Graph = new DecisionGraph(data);

        Debug.Log($"Loaded {data.nodes.Count} nodes. Start node id: {Graph.StartNode}");

        var startNode = Graph.GetNode(Graph.StartNode);
        if (startNode != null)
        {
            Debug.Log($"Start node text: {startNode.text}. Options count: {startNode.options.Count}");
        }
    }
}
