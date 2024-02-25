using UnityEngine;
public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.PlayerRb.gravityScale = playerData.gravityScale * 1.8f;
    }

    public override void Exit()
    {
        base.Exit();
        player.PlayerRb.gravityScale = playerData.gravityScale;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.PlayerRb.velocity.y < playerData.maxFallSpeed)
        {
            player.PlayerRb.velocity = new Vector2(player.PlayerRb.velocity.x, playerData.maxFallSpeed);
        }
    }
}