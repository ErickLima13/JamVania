using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName) : base(player, stateMachine, playerData, animName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        playerData.canDash = true;
        playerData.canDoubleJump = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.PlayerRb.velocity = new Vector2(input.x * playerData.speed, player.PlayerRb.velocity.y);

        if (player.IsGrounded())
        {
            if (player.InputControl.Jump_Input_Pressed)
            {
                Debug.Log("Jump Used");
                stateMachine.ChangeState(player.JumpState);
                return;
            }

            if (player.InputControl.Attack_Input_Pressed)
            {
                stateMachine.ChangeState(player.MainAttackState);
                return;
            }

            if (player.TryDash())
            {
                stateMachine.ChangeState(player.DashState);
                return;
            }
        }

     
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    
}
