using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator animator;
    private HitBox hitBox;

    private bool isLeft;
    private bool isAttack;
    private bool isGrounded;

    private int attackCounter;

    private float inputX;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float attackTimer;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private LayerMask groundMask;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hitBox = GetComponentInChildren<HitBox>();
    }

    void Update()
    {
        inputX = UserInput.Instance.MoveInput.x;

        Move();
        MainAttack();
        Jump();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundMask);
    }

    private void Flip()
    {
        isLeft = !isLeft;
        float scaleX = transform.localScale.x;
        scaleX *= -1f;
        transform.localScale = new(scaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Move()
    {
        if (inputX != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        playerRb.velocity = new Vector2(inputX * speed, playerRb.velocity.y);

      
    }

    private void Jump()
    {
        if (UserInput.Instance.Jump_Input_Pressed && isGrounded)
        {
            playerRb.AddForce(new(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void MainAttack()
    {
        if (UserInput.Instance.Attack_Input_Pressed && !isAttack && inputX == 0)
        {
            isAttack = true;

            StopCoroutine(nameof(ComboAttack));
            StartCoroutine(ComboAttack());


            if (attackCounter == 0)
            {
                animator.SetTrigger("attack" + 1);
                attackCounter++;
                hitBox.SetDamage(attackCounter);
            }
            else if (attackCounter == 1)
            {            
                animator.SetTrigger("attack" + 2);
                attackCounter++;
                hitBox.SetDamage(attackCounter);
            }
            else if (attackCounter == 2)
            {
                hitBox.SetDamage(attackCounter);
                animator.SetTrigger("attack" + 3);
                attackCounter = 0;
            }
        }     
    }

    private IEnumerator ComboAttack()
    {
        yield return new WaitForSeconds(attackTimer);

        attackCounter = 0;
        
    }

    public void EndAttack()
    {
        StartCoroutine(StopAttack());
    }

    private IEnumerator StopAttack()
    {
        yield return new WaitForEndOfFrame();
        isAttack = false;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, boxSize);    
    }
#endif

}

