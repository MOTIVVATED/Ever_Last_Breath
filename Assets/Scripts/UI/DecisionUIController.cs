using UnityEngine;
using TMPro;

public class DecisionUIController : MonoBehaviour
{
    public TextMeshProUGUI decisionPanel;
    public Transform optionsContainer;
    public GameObject optionLabelPrefab;

    public void DisplayNode(DecisionNode node)
    {
        for (int i = optionsContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(optionsContainer.GetChild(i).gameObject);
        }

        decisionPanel.text = node.text;

        foreach (DecisionOption option in node.options)
        {
            GameObject instance = Instantiate(optionLabelPrefab, optionsContainer);
            TextMeshProUGUI label = instance.GetComponentInChildren<TextMeshProUGUI>();
            label.text = option.label;
        }
    }
}
