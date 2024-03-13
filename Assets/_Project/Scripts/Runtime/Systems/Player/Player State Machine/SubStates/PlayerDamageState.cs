using UnityEngine;

public class PlayerDamageState : PlayerState
{
    public Vector2 direction;

    public PlayerDamageState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        PlayFeedback();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time > startTime + playerData.delay)
        {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


    public void PlayFeedback()
    {
        if (direction.x > player.transform.position.x) // left knockback
        {
            direction = new(-1, .7f);
        }
        else if (direction.x < player.transform.position.x) // right
        {
            direction = new(1, .7f);
        }

        player.PlayerRb.velocity = direction * playerData.strength;
    }
}
