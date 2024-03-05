using UnityEngine;

public class EarthBoss : MonoBehaviour
{
    public EarthState state;

    public JumpAttackState jumpAttackState;
    public DashAttackState dashAttackState;
    public IdleState idleState;
    public BombAttackState bombAttackState;

    [SerializeField] private BossData bossData;

    private void Start()
    {
        jumpAttackState.Setup(bossData, this);
        dashAttackState.Setup(bossData, this);
        idleState.Setup(bossData, this);
        bombAttackState.Setup(bossData, this);
        ChangeState(idleState);
    }

    private void Update()
    {
        state.Do();
    }

    public void ChangeState(EarthState newState)
    {
        state?.Exit();
        state = newState;
        state.Enter();
    }
}
