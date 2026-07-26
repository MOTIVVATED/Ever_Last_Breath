using UnityEngine;

public class DecisionGraphLoader : MonoBehaviour
{
    [SerializeField] private TextAsset graphJsonRu;
    [SerializeField] private TextAsset graphJsonEn;

    public DecisionGraph Graph { get; private set; }

    public void LoadGraph()
    {
        TextAsset graphJson = LocalizationManager.CurrentLanguage == "ru" ? graphJsonRu : graphJsonEn;

        var data = JsonUtility.FromJson<DecisionGraphData>(graphJson.text);
        Graph = new DecisionGraph(data);

        Debug.Log($"Loaded {data.nodes.Count} nodes. Start node id: {Graph.StartNode}");
    }
}
