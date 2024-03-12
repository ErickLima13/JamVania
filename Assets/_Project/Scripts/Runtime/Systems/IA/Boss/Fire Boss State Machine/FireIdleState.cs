using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIdleState : FireState
{
    [SerializeField] private List<FireState> fireStates = new();

    private int idState;

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
        if (idState >= fireStates.Count)
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

        fireBoss.ChangeState(fireStates[idState]);
    }
}
