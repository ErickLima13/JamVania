using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

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

    }

    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck()
    {

    }
}
