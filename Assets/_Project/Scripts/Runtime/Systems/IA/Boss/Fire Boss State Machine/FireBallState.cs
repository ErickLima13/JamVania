using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBallState : FireState
{
    [SerializeField] private GameObject fireBallPrefab;


    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        FireBall();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    private void FireBall()
    {
        StartCoroutine(DelayShoot());
    }

    private IEnumerator DelayShoot()
    {

        yield return new WaitForSeconds(0.5f);

        GameObject temp = Instantiate(fireBallPrefab, transform.position, fireBoss.transform.rotation);
        temp.transform.localScale = new(temp.transform.localScale.x * fireBoss.transform.localScale.x, temp.transform.localScale.y);

        yield return new WaitForSeconds(1f);

        fireBoss.ChangeState(fireBoss.idleState);


    }
}
