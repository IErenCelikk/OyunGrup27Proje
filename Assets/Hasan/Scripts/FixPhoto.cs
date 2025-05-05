using UnityEngine;

public class FixPhoto : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;

    void Start()
    {
        FitSpriteToScreen(sr);
    }

    void FitSpriteToScreen(SpriteRenderer sr)
    {
        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight * Camera.main.aspect;

        float spriteHeight = sr.sprite.bounds.size.y;
        float spriteWidth = sr.sprite.bounds.size.x;

        sr.transform.localScale = new Vector3(screenWidth / spriteWidth, screenHeight / spriteHeight, 1);
    }

}
