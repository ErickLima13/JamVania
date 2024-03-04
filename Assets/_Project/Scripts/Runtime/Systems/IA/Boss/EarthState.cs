using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthState : MonoBehaviour
{
    protected EarthBoss earthBoss;
    protected EarthStateMachine stateMachine;
    protected BossData bossData;
    protected Vector2 input;

    protected bool canFlip = true;

    protected float startTime;

    protected string animName;

    public EarthState(EarthBoss earthBoss, EarthStateMachine stateMachine, BossData bossData, string animName)
    {
        this.earthBoss = earthBoss;
        this.stateMachine = stateMachine;
        this.bossData = bossData;
        this.animName = animName;
    }

    public virtual void Enter()
    {
        DoCheck();
       // player.Animator.Play(animName);
        startTime = Time.time;
        Debug.Log(animName);
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {
        //input = player.InputControl.MoveInput;
        //if (canFlip)
        //{
        //    Flip();
        //}
    }

    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck()
    {

    }
}
