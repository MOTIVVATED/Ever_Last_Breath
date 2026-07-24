using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
    public RectTransform heroMarker;
    public RectTransform deathMarker;
    public float leftX = 20f;
    public float rightX = 1900f;

    public void SetHeroPosition(float normalized)
    {
        Vector2 pos = heroMarker.anchoredPosition;
        pos.x = Mathf.Lerp(leftX, rightX, normalized);
        heroMarker.anchoredPosition = pos;
    }

    public void SetDeathPosition(float normalized)
    {
        Vector2 pos = deathMarker.anchoredPosition;
        pos.x = Mathf.Lerp(leftX, rightX, normalized);
        deathMarker.anchoredPosition = pos;
    }
}
