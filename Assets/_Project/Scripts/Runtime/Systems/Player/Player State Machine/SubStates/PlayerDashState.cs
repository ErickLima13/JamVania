using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    private float timer;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        playerData.canDash = false;
        timer = playerData.dashTimer;
        player.PlayerRb.velocity = Vector3.zero;
        player.PlayerRb.gravityScale = 0;
        player.PlayerRb.velocity = new Vector2 (playerData.dashForce * player.transform.localScale.x, 0);
    }

    public override void Exit()
    {
        base.Exit();

        player.PlayerRb.gravityScale = playerData.gravityScale;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
