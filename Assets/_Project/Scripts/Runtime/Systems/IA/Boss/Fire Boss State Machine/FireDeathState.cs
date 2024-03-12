using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDeathState : FireState
{
    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();
        fireBoss.isDied = true;
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
