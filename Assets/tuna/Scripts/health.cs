using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] public float healthAmount;
    private SpriteRenderer SpriteRenderer;
    private Color currentColor;
    private Color targetColor = Color.red;

    [Range(0f, 1f)]
    [SerializeField] private float redStep = 0.1f;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = SpriteRenderer.color;    
    }
    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        currentColor = Color.Lerp(currentColor, targetColor, redStep);
        SpriteRenderer.color = currentColor;
        if(healthAmount == 0f)
        {
            Debug.Log("öldü");
        }
    }
}
