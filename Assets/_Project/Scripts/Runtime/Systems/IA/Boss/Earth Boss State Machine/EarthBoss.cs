using UnityEngine;

public class EarthBoss : MonoBehaviour
{
    public EarthState state;

    public JumpAttackState jumpAttackState;
    public DashAttackState dashAttackState;
    public IdleState idleState;
    public BombAttackState bombAttackState;
    public DeathState deathState;

    [SerializeField] private BossData bossData;

    public Animator animator;

    private Status status;

    public bool isDied;

    private void Start()
    {
        status = GetComponent<Status>();

        jumpAttackState.Setup(bossData, this);
        dashAttackState.Setup(bossData, this);
        idleState.Setup(bossData, this);
        bombAttackState.Setup(bossData, this);
        deathState.Setup(bossData, this);
        ChangeState(idleState);

        status.OnDie += DieAnim;
    }

    private void Update()
    {
        state.Do();
    }

    public void ChangeState(EarthState newState)
    {
        if(!isDied)
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
