using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        

        Jump();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.TryDash())
        {
            stateMachine.ChangeState(player.DashState);
            return;
        }
        if (player.InputControl.Jump_Input_Released)
        {
            player.PlayerRb.velocity = new Vector2(player.PlayerRb.velocity.x, player.PlayerRb.velocity.y * .1f);
        }
        if(player.PlayerRb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.FallState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void Jump()
    {
        player.PlayerRb.velocity = new Vector2(player.PlayerRb.velocity.x, playerData.jumpForce);
    }
}
public class PlayerTransitionState : PlayerState
{
    public PlayerTransitionState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        canFlip = false;
        player.PlayerRb.gravityScale = 0;
        player.PlayerRb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
        player.PlayerRb.gravityScale = playerData.gravityScale;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
