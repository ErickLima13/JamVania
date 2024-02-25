using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.IsGrounded() && player.PlayerRb.velocity.y <= 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }

        if (player.InputControl.Attack_Input_Pressed)
        {
            stateMachine.ChangeState(player.MainAttackState);
            return;
        }

        if (player.TryDoubleJump())
        {
            playerData.canDoubleJump = false;
            stateMachine.ChangeState(player.JumpState);
            return;
        }
        if (player.TryDash())
        {
            stateMachine.ChangeState(player.DashState);
            return;
        }
        player.PlayerRb.velocity = new Vector2(input.x * playerData.speed, player.PlayerRb.velocity.y);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
