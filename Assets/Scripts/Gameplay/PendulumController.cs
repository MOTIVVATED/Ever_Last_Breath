using UnityEngine;

public class PendulumController : MonoBehaviour
{
    public Transform pivot;
    public float amplitude = 60f;
    public float angularSpeed = 2f;

    private float angle;

    public float NormalizedPosition => (angle + amplitude) / (2f * amplitude);
    public float CurrentAngle => angle;

    private void Update()
    {
        angle = amplitude * Mathf.Sin(Time.time * angularSpeed);
        pivot.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}
