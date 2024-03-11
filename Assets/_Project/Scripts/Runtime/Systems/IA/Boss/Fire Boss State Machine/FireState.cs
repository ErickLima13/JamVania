using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : MonoBehaviour
{
    protected float startTime;

    protected BossData bossData;

    protected FireBoss fireBoss;

    [SerializeField] protected string animName;

    public virtual void Enter()
    {
        fireBoss.animator.Play(animName);
        Debug.LogWarning(gameObject.name);
    }

    public virtual void Do()
    {
    }

    public virtual void FixedDo()
    {
    }

    public virtual void Exit()
    {
    }

    public void Setup(BossData bossData, FireBoss fireBoss)
    {
        this.bossData = bossData;
        this.fireBoss = fireBoss;
    }
}
