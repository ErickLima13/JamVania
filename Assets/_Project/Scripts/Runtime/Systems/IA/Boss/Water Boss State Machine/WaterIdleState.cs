using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterIdleState : WaterState
{
    [SerializeField] private List<WaterState> waterStates = new ();

    public int idState;

    public int idleTimer;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(IdleDelay());
    }

    public override void Exit()
    {
        base.Exit();

        idState++;
        if (idState >= waterStates.Count)
        {
            idState = 0;
        }
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    private IEnumerator IdleDelay()
    {
        yield return new WaitForSeconds(idleTimer);

        waterBoss.ChangeState(waterStates[idState]);
    }
}
