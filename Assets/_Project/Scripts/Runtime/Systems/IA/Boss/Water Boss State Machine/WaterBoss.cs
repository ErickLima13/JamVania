using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoss : MonoBehaviour
{
    public WaterState state;

    public WaterWaveState waterWave;
    public WaterBubbleState bubbleState;
    public WaterIdleState idleState;
    public WaterThornState thornState;

    [SerializeField] private BossData bossData;

    private void Start()
    {
        waterWave.Setup(bossData, this);
        bubbleState.Setup(bossData, this);
        idleState.Setup(bossData, this);
        thornState.Setup(bossData, this);
        ChangeState(idleState);
    }

    private void Update()
    {
        state.Do();
    }

    public void ChangeState(WaterState newState)
    {
        state?.Exit();
        state = newState;
        state.Enter();
    }
}
