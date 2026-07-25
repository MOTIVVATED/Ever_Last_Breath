using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public event Action OnDecisionMade;

    public DecisionGraphLoader graphLoader;
    public DecisionUIController uiController;
    public PendulumController pendulum;
    public ProgressBarController progressBar;
    public GameOverUIController gameOverUI;
    public Animator heroAnimator;

    public GameObject optionsContainerRoot;
    public GameObject pendulumRoot;
    public GameObject progressBarRoot;

    public float deathApproachSpeed = 0.15f;

    private const float deltaUnit = 0.05f;

    private DecisionNode currentNode;
    private float heroPosition = 0f;
    private float deathPosition = 1f;
    private bool isGameOver = false;

    private void Start()
    {
        DecisionNode startNode = graphLoader.Graph.GetNode(graphLoader.Graph.StartNode);
        ShowNode(startNode);
    }

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        deathPosition = Mathf.Max(heroPosition, deathPosition - deathApproachSpeed * Time.deltaTime);
        progressBar.SetDeathPosition(deathPosition);

        if (deathPosition <= heroPosition)
        {
            TriggerGameOver("caught_by_death");
            return;
        }

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            HandleDecision();
        }
    }

    private void ShowNode(DecisionNode node)
    {
        currentNode = node;
        uiController.DisplayNode(node);
        deathPosition = 1f;
        progressBar.SetDeathPosition(1f);
        progressBar.SetHeroPosition(heroPosition);
        PlayHeroState(node.heroState);
    }

    private void HandleDecision()
    {
        int optionsCount = currentNode.options.Count;
        int index = Mathf.Clamp(Mathf.FloorToInt(pendulum.NormalizedPosition * optionsCount), 0, optionsCount - 1);
        DecisionOption option = currentNode.options[index];

        OnDecisionMade?.Invoke();

        heroPosition = Mathf.Clamp01(heroPosition + option.deathDelta * deltaUnit);

        if (!string.IsNullOrEmpty(option.ending))
        {
            TriggerGameOver(option.ending);
            return;
        }

        DecisionNode nextNode = graphLoader.Graph.GetNode(option.next);
        if (nextNode == null)
        {
            Debug.LogError($"Invalid node id: '{option.next}'");
            return;
        }

        ShowNode(nextNode);
    }

    private void TriggerGameOver(string reason)
    {
        isGameOver = true;

        optionsContainerRoot.SetActive(false);
        pendulumRoot.SetActive(false);

        string endingText = graphLoader.Graph.GetEndingText(reason);
        PlayHeroState(graphLoader.Graph.GetEndingHeroState(reason));
        gameOverUI.ShowEnding(endingText);

        Debug.Log($"Game Over: {reason}");
    }

    private void PlayHeroState(string heroState)
    {
        heroAnimator.Play("hero" + heroState);
    }
}
