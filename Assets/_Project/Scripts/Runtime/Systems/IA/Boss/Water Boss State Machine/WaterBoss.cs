using UnityEngine;

public class WaterBoss : MonoBehaviour
{
    public WaterState state;

    public WaterWaveState waterWave;
    public WaterBubbleState bubbleState;
    public WaterIdleState idleState;
    public WaterThornState thornState;
    public WaterDeathState deathState;

    public Animator animator;

    private Status status;

    [SerializeField] private BossData bossData;

    public bool isDied;

    private void Start()
    {
        status = GetComponent<Status>();
        status.OnDie += DieAnim;

        waterWave.Setup(bossData, this);
        bubbleState.Setup(bossData, this);
        idleState.Setup(bossData, this);
        thornState.Setup(bossData, this);
        deathState.Setup(bossData, this);
        ChangeState(idleState);
    }

    private void Update()
    {
        state.Do();
    }

    public void ChangeState(WaterState newState)
    {
        if (!isDied)
        {
            state?.Exit();
            state = newState;
            state.Enter();
        }
    }

    private void DieAnim()
    {
        ChangeState(deathState);
    }

    private void OnDestroy()
    {
        status.OnDie += DieAnim;
    }
}
