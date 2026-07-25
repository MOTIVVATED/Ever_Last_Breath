using UnityEngine;

public class PendulumTickSoundPlayer : MonoBehaviour
{
    [SerializeField] private PendulumController pendulum;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip tickLeftToRight;
    [SerializeField] private AudioClip tickRightToLeft;

    private float previousAngle;

    private void Update()
    {
        float currentAngle = pendulum.CurrentAngle;

        if (previousAngle < 0f && currentAngle >= 0f)
        {
            if (tickLeftToRight != null)
            {
                audioSource.PlayOneShot(tickLeftToRight);
            }
        }
        else if (previousAngle > 0f && currentAngle <= 0f)
        {
            if (tickRightToLeft != null)
            {
                audioSource.PlayOneShot(tickRightToLeft);
            }
        }

        previousAngle = currentAngle;
    }
}
