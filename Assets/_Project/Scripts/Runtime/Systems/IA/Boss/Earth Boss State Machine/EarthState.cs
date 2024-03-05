using UnityEngine;

public class EarthState : MonoBehaviour
{
    protected float startTime;

    protected BossData bossData;

    protected EarthBoss earthBoss;

    public virtual void Enter()
    {
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

    public void Setup(BossData bossData, EarthBoss earthBoss)
    {
        this.bossData = bossData;
        this.earthBoss = earthBoss;
    }
}
