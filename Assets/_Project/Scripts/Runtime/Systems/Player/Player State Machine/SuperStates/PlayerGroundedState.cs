using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 input;

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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.IsGrounded())
        {
            if (player.InputControl.Jump_Input_Pressed)
            {
                stateMachine.ChangeState(player.JumpState);
                return;
            }

            if (player.InputControl.Attack_Input_Pressed)
            {
                stateMachine.ChangeState(player.MainAttackState);
                return;
            }

            input = player.InputControl.MoveInput;

            Flip();
        }

     
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void Flip()
    {
        float scalex = player.transform.localScale.x;

        if (input.x > 0)
        {
            scalex = 1;
        }
        if (input.x < 0)
        {
            scalex = -1;
        }

        player.transform.localScale = new(scalex, player.transform.localScale.y, player.transform.localScale.z);

    }
}
