using System.Collections;
using UnityEngine;

public class WaterBubbleState : WaterState
{
    [SerializeField] private GameObject bubblePrefab;

    //[SerializeField] private int numBubbles;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        ShootBubbles();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    private void ShootBubbles()
    {
        StartCoroutine(DelayShoot());
    }

    private IEnumerator DelayShoot()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject temp = Instantiate(bubblePrefab, waterBoss.transform.position, waterBoss.transform.rotation);

        yield return new WaitForSeconds(0.5f);

        waterBoss.ChangeState(waterBoss.idleState);
    }
}
