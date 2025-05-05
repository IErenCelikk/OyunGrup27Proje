using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;  
    public float fadeDuration = 2f;       
    private float fadeTimer = 0f;         

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime; 
            float alpha = Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration);
            Color currentColor = spriteRenderer.color;
            currentColor.a = alpha;  
            spriteRenderer.color = currentColor;
        }
    }

    public void StartFade()
    {
        fadeTimer = 0f; 
    }
}
