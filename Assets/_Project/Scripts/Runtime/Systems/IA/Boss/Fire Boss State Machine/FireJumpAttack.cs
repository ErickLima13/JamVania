using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireJumpAttack : FireState
{
    public float jumpForce;

    public Transform wallCheck;

    public float direction;

    public bool isLeft;

    public GameObject fireAttack;

    public override void Do()
    {
        base.Do();

        RaycastHit2D wall = Physics2D.Raycast(wallCheck.position, Vector2.right * direction, bossData.wallDistance, fireBoss.groundMask);
        Debug.DrawRay(wallCheck.position, Vector2.right * direction * bossData.wallDistance, Color.yellow);

        if (wall.collider)
        {
            Flip();
            isLeft = !isLeft;
        }

    }

    public override void Enter()
    {
        base.Enter();

        fireBoss.body2d.velocity = new Vector2(direction * jumpForce/2 , jumpForce);
        StartCoroutine(JumpAttack());
    }

    private IEnumerator JumpAttack()
    {
        yield return new WaitForSeconds(0.5f);

        if (fireBoss.isGrounded)
        {
            fireAttack.SetActive(true);
            yield return new WaitForSeconds(1f);
            fireAttack.SetActive(false);
            fireBoss.ChangeState(fireBoss.idleState);
        }
        else
        {
            StartCoroutine(JumpAttack());
        }
    }

    private void Flip()
    {
        float scaleX = fireBoss.transform.localScale.x;

        if (isLeft)
        {
            scaleX *= -1f;
            direction = scaleX;
        }
        else
        {
            scaleX *= -1f;
            direction = scaleX;
        }

        fireBoss.transform.localScale = new(scaleX, fireBoss.transform.localScale.y, fireBoss.transform.localScale.z);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }
}
