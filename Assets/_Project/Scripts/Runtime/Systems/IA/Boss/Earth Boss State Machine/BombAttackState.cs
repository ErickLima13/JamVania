using System.Collections;
using UnityEngine;

public class BombAttackState : EarthState
{
    public GameObject bombPrefab;

    public int numBombs;

    private int currentBombs = 0;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        ShootBomb();
    }

    public override void Exit()
    {
        base.Exit();

        currentBombs = 0;
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    private void ShootBomb()
    {
        StartCoroutine(DelayShoot());
    }

    private IEnumerator DelayShoot()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject temp = Instantiate(bombPrefab, earthBoss.transform.position, earthBoss.transform.rotation);
        temp.transform.localScale = new(temp.transform.localScale.x * earthBoss.transform.localScale.x, temp.transform.localScale.y);

        currentBombs++;

        if (numBombs > currentBombs)
        {
            ShootBomb();
        }
        else
        {
            earthBoss.ChangeState(earthBoss.idleState);
        }
    }
}
