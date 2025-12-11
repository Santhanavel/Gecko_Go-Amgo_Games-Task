using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text text;
    [SerializeField] private Button button;

    private float iconYMoveValue = 50;
    private float moveSpeed = 1;

    private float scaleValue = 1.25f;
    private float scaleSpeed = 1;

    // Original values stored here
    private Vector3 iconDefaultPos;
    private Vector3 textDefaultPos;
    private Vector3 defaultScale;

    private Coroutine animationRoutine;

    private void Awake()
    {
        // Store default values
        iconDefaultPos = icon.rectTransform.anchoredPosition;
        textDefaultPos = text.rectTransform.anchoredPosition;
        defaultScale = transform.localScale;

        // Subscribe button event
        button.onClick.AddListener(AnimateToSelected);
    }

    // Smooth animate INTO clicked state
    public void AnimateToSelected()
    {
        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        animationRoutine = StartCoroutine(Animate(true));
    }

    // Smooth animate BACK to original state
    public void AnimateToDefault()
    {
        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        animationRoutine = StartCoroutine(Animate(false));
    }

    private IEnumerator Animate(bool toSelected)
    {
        float t = 0f;

        // Movement start values
        Vector3 iconStart = icon.rectTransform.anchoredPosition;
        Vector3 textStart = text.rectTransform.anchoredPosition;

        // Movement target
        Vector3 iconTarget = toSelected ?
            iconDefaultPos + new Vector3(0, iconYMoveValue, 0) : iconDefaultPos;

        Vector3 textTarget = toSelected ?
            textDefaultPos + new Vector3(0, iconYMoveValue, 0) : textDefaultPos;
        
        // Scale start & target
        Vector3 scaleStart = transform.localScale;
        Vector3 scaleTarget = toSelected ?
            defaultScale * scaleValue : defaultScale;

        while (t < 1f)
        {
            // Movement time
            float moveT = t;

            // Scale time (separate speed)
            float scaleT = Mathf.Clamp01(t * (scaleSpeed / moveSpeed));

            // Move and scale PARALLEL
            icon.rectTransform.anchoredPosition = Vector3.Lerp(iconStart, iconTarget, moveT);
            text.rectTransform.anchoredPosition = Vector3.Lerp(textStart, textTarget, moveT);
            transform.localScale = Vector3.Lerp(scaleStart, scaleTarget, scaleT);

            // Global time
            t += Time.deltaTime * moveSpeed;

            yield return null;
        }
        text.gameObject.SetActive(toSelected);
        // Snap final values to remove floating error
        icon.rectTransform.anchoredPosition = iconTarget;
        text.rectTransform.anchoredPosition = textTarget;
        transform.localScale = scaleTarget;
    }

}
