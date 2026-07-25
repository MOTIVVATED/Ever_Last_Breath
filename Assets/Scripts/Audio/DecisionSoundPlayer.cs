using UnityEngine;

public class DecisionSoundPlayer : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] decisionSounds;

    private void OnEnable()
    {
        if (gameManager != null)
        {
            gameManager.OnDecisionMade += PlayRandomSound;
        }
    }

    private void OnDisable()
    {
        if (gameManager != null)
        {
            gameManager.OnDecisionMade -= PlayRandomSound;
        }
    }

    private void PlayRandomSound()
    {
        if (decisionSounds == null || decisionSounds.Length == 0)
        {
            return;
        }

        AudioClip clip = decisionSounds[Random.Range(0, decisionSounds.Length)];
        audioSource.PlayOneShot(clip);
    }
}
