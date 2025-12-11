using UnityEngine;
using System.Collections;
public class MenuButtonHighlight : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;   // The object to animate
    [SerializeField] private float moveSpeed = 3f;          // Animation speed

    private Coroutine animationRoutine;

    public void AnimateToSelected(RectTransform target)
    {
        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        animationRoutine = StartCoroutine(Animate(target));
    }

    private IEnumerator Animate(RectTransform target)
    {
        float t = 0f;

        // Start values
        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 endPos = target.anchoredPosition;
        endPos.y = -50;

        while (t < 1f)
        {
            float lerpT = t;

            // Movement (parallel)
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, lerpT);
            t += Time.deltaTime * moveSpeed;
            yield return null;
        }

        // Snap to final values
        rectTransform.anchoredPosition = endPos;
    }

}
