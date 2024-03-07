using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : EarthState
{
    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        earthBoss.isDied = true;
        //Destroy(earthBoss.gameObject,2f);
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
