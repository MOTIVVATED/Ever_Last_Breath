using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUIController : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI endingText;
    public Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(Restart);
    }

    public void ShowEnding(string text)
    {
        panel.SetActive(true);
        endingText.text = text;

        TextMeshProUGUI restartButtonText = restartButton.GetComponentInChildren<TextMeshProUGUI>();
        restartButtonText.text = LocalizationManager.CurrentLanguage == "ru" ? "Заново" : "Restart";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
