using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterThornState : WaterState
{
    [SerializeField] private GameObject thornPrefab;

    [SerializeField] private List<Transform> thornPositions = new();

    public int randPos;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        randPos = Random.Range(0,thornPositions.Count);
        IceThornAttack();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    private void IceThornAttack()
    {
        GameObject temp = Instantiate(thornPrefab, thornPositions[randPos].position,Quaternion.identity);

        StartCoroutine(DelayTime());
    }

    private IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(3f);

        waterBoss.ChangeState(waterBoss.idleState);

    }
}
