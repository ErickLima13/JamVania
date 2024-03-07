using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterState : MonoBehaviour
{
    protected float startTime;

    protected BossData bossData;

    protected WaterBoss waterBoss;

    [SerializeField] protected string animName;

    public virtual void Enter()
    {
        waterBoss.animator.Play(animName);
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

    public void Setup(BossData bossData, WaterBoss waterBoss)
    {
        this.bossData = bossData;
        this.waterBoss = waterBoss;
    }
}
