using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] public float healthAmount;
    //private GameObject GameObject;
    private Animator Animator;
    private SpriteRenderer SpriteRenderer;
    private Color currentColor;
    private Color targetColor = Color.red;

    [Range(0f, 1f)]
    [SerializeField] private float redStep = 0.1f;

    void Start()
    {
        //GameObject = GetComponent<GameObject>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        currentColor = SpriteRenderer.color;    
    }
    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        currentColor = Color.Lerp(currentColor, targetColor, redStep);
        SpriteRenderer.color = currentColor;

        if(CompareTag("Player"))
        {
            Animator.SetBool("isTakeDamage",true);
        }
        else
        {
            Animator.SetTrigger("isTakeDamage");
        }
        if (healthAmount == 0f)
        {
            Debug.Log("öldü");
            if (gameObject.CompareTag("Player"))
            {
                Animator.SetTrigger("isDeath");
            }
            else
            {
                Animator.SetBool("isDeath", true);
            }
            //gameObject.SetActive(false);
        }
    }

    public void EndTakeDamageAnim()
    {
        if (CompareTag("Player"))
           Animator.SetBool("isTakeDamage", false);
    }
}
