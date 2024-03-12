using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EarthState
{
    public List<EarthState> earthStates = new();

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

    private IEnumerator IdleDelay()
    {
        yield return new WaitForSeconds(idleTimer);

        earthBoss.ChangeState(earthStates[idState]);
    }

    public override void Exit()
    {
        base.Exit();

        idState++;
        if (idState >= earthStates.Count)
        {
            idState = 0;
        }
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }
}
