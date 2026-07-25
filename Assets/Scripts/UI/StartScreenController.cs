using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject continueHint;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject panelRoot;
    [SerializeField] private GameManager gameManager;

    private string[] lines =
    {
        "Здравствуй. Ты уже знаешь, кто я.",
        "Каждое мгновение — это шаг либо ко мне, либо от меня.",
        "Слушай маятник. Когда он укажет на решение — нажми Пробел.",
        "Промедлишь — и я подойду ближе. Каждый твой выбор отбрасывает меня назад.",
        "Дыши, пока можешь. Начнём?"
    };

    private int currentLine = 0;

    private void Start()
    {
        startButton.gameObject.SetActive(false);
        startButton.onClick.AddListener(BeginGame);
        ShowLine(0);
    }

    private void Update()
    {
        if (currentLine < lines.Length - 1 && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            currentLine++;
            ShowLine(currentLine);
        }
    }

    private void ShowLine(int index)
    {
        dialogueText.text = lines[index];

        if (index == lines.Length - 1)
        {
            continueHint.SetActive(false);
            startButton.gameObject.SetActive(true);
        }
        else
        {
            continueHint.SetActive(true);
            startButton.gameObject.SetActive(false);
        }
    }

    private void BeginGame()
    {
        panelRoot.SetActive(false);
        gameManager.BeginGame();
    }
}
