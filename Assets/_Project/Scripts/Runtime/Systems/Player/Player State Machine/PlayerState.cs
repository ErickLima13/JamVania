using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected Vector2 input;

    protected bool canFlip = true;

    protected float startTime;

    protected string animName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animName = animName;

        player.OnAnimationEndEvent += AnimationEnd;
    }

    public virtual void AnimationEnd(string animation)
    {

    }

    public virtual void Enter()
    {
        DoCheck();
        player.Animator.Play(animName);
        startTime = Time.time;
        Debug.Log(animName);
    }

    public virtual void Exit()
    {
       
    }

    public virtual void LogicUpdate()
    {
        input = player.InputControl.MoveInput;
        if (canFlip)
        {
            Flip();
        }
    }

    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck()
    {

    }
    public void Flip()
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
