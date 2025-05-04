using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class characterController : MonoBehaviour
{
    //Stats
    public characterStats characterStats;
    //Moving
    [SerializeField] private float moveDirection;
    private Rigidbody2D characterRb;
    private SpriteRenderer characterRen;
    //Dashing
    private TrailRenderer characterTrailRen;
    private bool canDash = true;
    private bool isDashing;
    //Animations
    private Animator characterAnimator;
    //attacking
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLy;
    [SerializeField] private float damage;

    private void Awake()
    {
        characterRb = GetComponent<Rigidbody2D>();
        characterRen = GetComponent<SpriteRenderer>();
        characterTrailRen = GetComponent<TrailRenderer>();
        characterAnimator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    private void FixedUpdate()
    {
        //Dash
        if(isDashing)
        {
            return;
        }

        characterRb.linearVelocity = new Vector2(characterStats.walkSpeed * moveDirection, characterRb.linearVelocity.y);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            characterAnimator.SetBool("isWalking", true);
        }
        //Dash
        if (isDashing)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {

            moveDirection = -1.0f;
            characterRen.flipX = true;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1.0f;
            characterRen.flipX = false;
        }
        else
        {
            moveDirection = 0.0f;
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.W) && canDash)
        {
            StartCoroutine(Dash());
            Debug.Log("bastý");
        }

        if (characterRb.linearVelocity == Vector2.zero)
        {
            characterAnimator.SetBool("isWalking", false);
        }
        else
        {
            characterAnimator.SetBool("isWalking", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            characterAnimator.SetBool("isAttacking",true);
        }
      
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = characterRb.gravityScale;
        characterRb.gravityScale = 0f;
        characterRb.linearVelocity = new Vector2(characterStats.dashingPower * moveDirection, characterRb.linearVelocity.y);
        characterTrailRen.emitting = true;
        yield return new WaitForSeconds(characterStats.dashingTime);
        characterTrailRen.emitting = false;
        characterRb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(characterStats.dashingCoolDown);
        canDash = true;
    }
    public void endAttack()
    {
        characterAnimator.SetBool("isAttacking", false);
    }
    public void characterAttack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemyLy);

        foreach (Collider2D colliderEnemy in enemy)
        {
            Debug.Log("Hit");
            colliderEnemy.GetComponent<health>().takeDamage(damage);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
