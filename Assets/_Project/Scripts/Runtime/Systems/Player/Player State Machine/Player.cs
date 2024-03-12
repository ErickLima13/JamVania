using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<string> OnAnimationEndEvent;

    public SoundEffects soundEffects;

    #region State machine
    public PlayerStateMachine StateMachine
    {
        get; private set;
    }
    public PlayerTransitionState TransitionState
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
    public PlayerFallState FallState
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

        TransitionState = new PlayerTransitionState(this, StateMachine, playerData, "idle");
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
        FallState = new PlayerFallState(this, StateMachine, playerData, "fall");
        MainAttackState = new PlayerMainAttackState(this, StateMachine, playerData, "attack2");
        DashState = new PlayerDashState(this, StateMachine, playerData, "dash");
    }

    private void Start()
    {
        soundEffects = GetComponentInChildren<SoundEffects>();
        Animator = GetComponent<Animator>();
        PlayerRb = GetComponent<Rigidbody2D>();
        HitBox = GetComponentInChildren<HitBox>();
        InputControl = UserInput.Instance;

        StateMachine.Initialize(IdleState);

        PlayerRb.gravityScale = playerData.gravityScale;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundMask);
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();   
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

    public bool TryDoubleJump()
    {
        if (InputControl.Jump_Input_Pressed && playerData.canDoubleJump && playerData.doubleJumpEnable && !isGrounded)
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
