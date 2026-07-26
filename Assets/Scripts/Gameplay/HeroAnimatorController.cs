using System.Collections.Generic;
using UnityEngine;

public class HeroAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private HashSet<string> validStateNames = new HashSet<string>();

    private void Awake()
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            validStateNames.Add(clip.name);
        }
    }

    public void SetState(string stateName)
    {
        if (string.IsNullOrEmpty(stateName) || !validStateNames.Contains(stateName))
        {
            Debug.LogWarning($"Неизвестное состояние аниматора: {stateName}");
            return;
        }

        animator.Play(stateName);
    }
}
