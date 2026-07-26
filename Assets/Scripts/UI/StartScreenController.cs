using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class StartScreenController : MonoBehaviour
{
    public static bool IntroAlreadyShown = false;

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject continueHint;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject panelRoot;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject languagePanel;
    [SerializeField] private Button englishButton;
    [SerializeField] private Button russianButton;
    [SerializeField] private DecisionGraphLoader graphLoader;

    private string[] linesRu =
    {
        "Здравствуй. Ты уже знаешь, кто я.",

				"Люди совершают около 500 миллионов вдохов до встречи со мной.",
        "Сколько вдохов осталось у тебя? Разве ты не считаешь их?",
				"Не волнуйся, у меня всё подсчитано.",

				"Как бы далеко ты не зашел, в конце тебя буду ждать только я.",
        "Слушай маятник. Когда он укажет на решение — нажми Пробел.",
        "Промедлишь — и я подойду ближе. Твои решения могут отсрочить нашу встречу.",
        "Начинай! Перед смертью не надышишься."
    };

    private string[] linesEn =
    {
        "Hello. You already know who I am.",

				"Human beings take about 500 million breaths before meeting me.",
				"How many breaths do you have left? Are not you counting down?",
				"Do not worry, I am doing it.",

				"No matter how far you go, only I will be waiting for you at the end.",
        "Listen to the pendulum. When it points to a decision — press Space.",
				"Hesitate, and I get closer. Your decisions can delay our meeting.",
				"Begin! Anyway, you can never breathe enough just before you die."
		};

    private const string ContinueHintRu = "Нажми Пробел, чтобы продолжить";
    private const string ContinueHintEn = "Press Space to continue";
    private const string StartButtonRu = "Начать";
    private const string StartButtonEn = "Begin";

    private string[] activeLines;
    private int currentLine = 0;

    private void Awake()
    {
        russianButton.onClick.AddListener(SelectRussian);
        englishButton.onClick.AddListener(SelectEnglish);
        startButton.onClick.AddListener(BeginGame);
    }

    private void Start()
    {
        if (IntroAlreadyShown)
        {
            languagePanel.SetActive(false);
            panelRoot.SetActive(false);
            graphLoader.LoadGraph();
            gameManager.BeginGame();
            return;
        }

        languagePanel.SetActive(true);
        dialogueText.gameObject.SetActive(false);
        continueHint.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (activeLines != null && currentLine < activeLines.Length - 1 && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            currentLine++;
            ShowLine(currentLine);
        }
    }

    private void ShowLine(int index)
    {
        dialogueText.text = activeLines[index];

        if (index == activeLines.Length - 1)
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

    private void SelectRussian()
    {
        LocalizationManager.CurrentLanguage = "ru";
        activeLines = linesRu;
        continueHint.GetComponent<TextMeshProUGUI>().text = ContinueHintRu;
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = StartButtonRu;
        BeginDialogue();
    }

    private void SelectEnglish()
    {
        LocalizationManager.CurrentLanguage = "en";
        activeLines = linesEn;
        continueHint.GetComponent<TextMeshProUGUI>().text = ContinueHintEn;
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = StartButtonEn;
        BeginDialogue();
    }

    private void BeginDialogue()
    {
        languagePanel.SetActive(false);
        dialogueText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        graphLoader.LoadGraph();
        ShowLine(0);
    }

    private void BeginGame()
    {
        IntroAlreadyShown = true;
        panelRoot.SetActive(false);
        gameManager.BeginGame();
    }
}
