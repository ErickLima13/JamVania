using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoss : MonoBehaviour
{
    public FireState state;

    public FireBallState fireBallState;
    public FireIdleState idleState;
    public FireDeathState deathState;
    public FireJumpAttack jumpAttack;
    public HitTheGround hitTheGround;

    public Animator animator;

    public Rigidbody2D body2d;

    public Transform groundCheck;
    public LayerMask groundMask;
    public Vector3 boxSize;
    public bool isGrounded;
    
    private Status status;

    [SerializeField] private BossData bossData;

    public bool isDied;

    private void Start()
    {
        status = GetComponent<Status>();
        body2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        jumpAttack.Setup(bossData, this);
        idleState.Setup(bossData, this);
        fireBallState.Setup(bossData, this);
        deathState.Setup(bossData, this);
        hitTheGround.Setup(bossData, this);

        ChangeState(idleState);

        status.OnDie += DieAnim;
    }

    private void Update()
    {
        state.Do();
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundMask);
    }

    public void ChangeState(FireState newState)
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

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, boxSize);
    }
#endif
}
