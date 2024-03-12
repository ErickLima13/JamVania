using UnityEngine;

public class DashAttackState : EarthState
{
    public Transform wallCheck;

    public LayerMask wallLayer;

    public bool isLeft;

    public float direction;

    public bool canDash;

    public BoxCollider2D hitDash;
    public void DashAttack()
    {
        hitDash.enabled = true;

        earthBoss.transform.Translate(Vector2.right * direction * bossData.speed * Time.deltaTime);

        RaycastHit2D wall = Physics2D.Raycast(wallCheck.position, Vector2.right * direction, bossData.wallDistance, wallLayer);
        Debug.DrawRay(wallCheck.position, Vector2.right * direction * bossData.wallDistance, Color.red);

        if (wall.collider)
        {
            canDash = false;

            isLeft = !isLeft;

            earthBoss.ChangeState(earthBoss.idleState);
        }
    }

    public override void Do()
    {
        base.Do();

        if (canDash)
        {
            DashAttack();
        }

    }

    public override void Enter()
    {
        base.Enter();

        canDash = true;

        print("dash");
    }

    public override void Exit()
    {
        base.Exit();

        hitDash.enabled = false;

        float scaleX = earthBoss.transform.localScale.x;

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

        earthBoss.transform.localScale = new(scaleX, earthBoss.transform.localScale.y, earthBoss.transform.localScale.z);
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }
}
