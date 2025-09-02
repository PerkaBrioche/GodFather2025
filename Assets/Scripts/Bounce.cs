using System.Collections;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool bounceOnEnable = false;
    public float bounceForce = 1.2f;
    [Tooltip("Durée pour atteindre le pic du bounce.")]
    public float bounceDecreaseSpeed = 2.5f;
    public float bounceDuration = 1f;
    public float bounceHeight = 0.5f;

    private Vector3 originalScale;
    private Vector3 originalPosition;

    private void Awake()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    private void OnEnable()
    {
        if (bounceOnEnable)
        {
            StartBounce();
        }
    }
    
    public void StartBounce()
    {
        StopAllCoroutines();
        StartCoroutine(BounceCoroutine());
    }
    
    private IEnumerator BounceCoroutine()
    {
        float timer = 0f;
        Vector3 targetScale = originalScale * bounceForce;
        Vector3 targetPosition = originalPosition + Vector3.up * bounceHeight;

        while (timer < bounceDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / bounceDuration);
            float smoothT = Mathf.SmoothStep(0f, 1f, t);
            transform.localScale = Vector3.Lerp(originalScale, targetScale, smoothT);
            transform.position = Vector3.Lerp(originalPosition, targetPosition, smoothT);
            yield return null;
        }

        while (timer > 0f)
        {
            timer -= Time.deltaTime * bounceDecreaseSpeed;
            float t = Mathf.Clamp01(timer / bounceDuration);
            float smoothT = Mathf.SmoothStep(0f, 1f, t);
            transform.localScale = Vector3.Lerp(originalScale, targetScale, smoothT);
            transform.position = Vector3.Lerp(originalPosition, targetPosition, smoothT);
            yield return null;
        }

        transform.localScale = originalScale;
        transform.position = originalPosition;
    }

    public void ResetBounce()
    {
        StopAllCoroutines();
        transform.localScale = originalScale;
        transform.position = originalPosition;
    }
}
