using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator animator;

    private bool isLeft;
    private bool isAttack;

    private int attackCounter;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float attackTimer;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        MainAttack();
        Jump();
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
        if (UserInput.Instance.MoveInput.x != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        playerRb.velocity = new Vector2(UserInput.Instance.MoveInput.x * speed, playerRb.velocity.y);

        if (isLeft && UserInput.Instance.MoveInput.x > 0)
        {
            Flip();
        }

        if (!isLeft && UserInput.Instance.MoveInput.x < 0)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (UserInput.Instance.Jump_Input_Pressed)
        {
            playerRb.AddForce(new(0, jumpForce));
        }
    }

    private void MainAttack()
    {
        if (UserInput.Instance.Attack_Input_Pressed && !isAttack)
        {
            isAttack = true;

            StopCoroutine(nameof(ComboAttack));
            StartCoroutine(ComboAttack());


            if (attackCounter == 0)
            {
                animator.SetTrigger("attack" + 1);
                attackCounter++;

            }
            else if (attackCounter == 1)
            {
                animator.SetTrigger("attack" + 2);
                attackCounter++;
            }
            else if (attackCounter == 2)
            {
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
}
