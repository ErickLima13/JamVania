using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<string> OnAnimationEndEvent;

    #region State machine
    public PlayerStateMachine StateMachine
    {
        get; private set;
    }

    public PlayerIdleState IdleState
    {
        get; private set;
    }

    public PlayerMoveState MoveState
    {
        get; private set;
    }

    public PlayerJumpState JumpState
    {
        get; private set;
    }

    public PlayerMainAttackState MainAttackState
    {
        get; private set;
    }

    public PlayerDashState DashState
    {
        get; private set;
    }

    public Animator Animator
    {
        get; private set;
    }

    public UserInput InputControl
    {
        get; private set;
    }

    [SerializeField] private PlayerData playerData;
    #endregion

    #region Player 
    private bool isGrounded;

    public Rigidbody2D PlayerRb
    {
        get; private set;
    }

    public HitBox HitBox
    {
        get; private set;
    }

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private LayerMask groundMask;

    #endregion

    private void Awake()
    {
        StateMachine = new();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
        MainAttackState = new PlayerMainAttackState(this, StateMachine, playerData, "attack2");
        DashState = new PlayerDashState(this, StateMachine, playerData, "dash");
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
        PlayerRb = GetComponent<Rigidbody2D>();
        HitBox = GetComponentInChildren<HitBox>();
        InputControl = UserInput.Instance;

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundMask);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public bool TryDash()
    {
        if (InputControl.Dash_Input_Pressed && playerData.canDash && playerData.dashEnable)
        {
            return true;
        }

        return false;
    }

    public void AnimationEnd(string animation)
    {
        OnAnimationEndEvent?.Invoke(animation);
    }

    private void OnDestroy()
    {
        OnAnimationEndEvent = null;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, boxSize);
    }
#endif
}
