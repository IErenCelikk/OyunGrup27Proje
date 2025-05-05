using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    #region Anim
    private Animator animator;
    private float horizontal;
    private float vertical;
    //private bool isAttacking;
    #endregion

    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        #region Anim
        animator = GetComponent<Animator>();
        #endregion
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        #region Anim

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //isAttacking = Input.GetButtonDown("Fire1");

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        //animator.SetBool("IsAttacking", isAttacking);
        #endregion
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal")) 
        {
            SceneManager.LoadScene("Oda1");
        }
    }
}
