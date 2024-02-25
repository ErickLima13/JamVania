using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainAttackState : PlayerAttackState
{
    public PlayerMainAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }

    public override void AnimationEnd(string animation)
    {
        base.AnimationEnd(animation);

        if(animation == animName)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        canFlip = false;
        player.HitBox.SetDamage(playerData.damage);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
