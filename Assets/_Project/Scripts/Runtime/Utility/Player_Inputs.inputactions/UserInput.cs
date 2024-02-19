using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput Instance;

    public UnityEvent AttackButtonEvent;

    public Vector2 MoveInput;

    public bool Jump_Input_Pressed, Jump_Input_Hold, Jump_Input_Released;
    public bool Dash_Input_Pressed, Dash_Input_Hold, Dash_Input_Released;
    public bool Attack_Input_Pressed, Attack_Input_Hold, Attack_Input_Released;
    public bool Special_Input_Pressed, Special_Input_Hold, Special_Input_Released;
    public bool LeftWeaponChange_Pressed, RightWeaponChange_Pressed;
    public bool UILeftWeaponChange_Pressed, UIRightWeaponChange_Pressed;
    public bool Pause_Input_Pressed;
    public bool UI_Pause_Input_Pressed;

    public static PlayerInput PlayerInput;

    private InputAction _dirInputAction;
    private InputAction _jumpInputAction;
    private InputAction _dashInputAction;
    private InputAction _attackInputAction;
    private InputAction _specialInputAction;
    private InputAction _leftWeaponChangeInputAction;
    private InputAction _rightWeaponChangeInputAction;
    private InputAction _pauseInputAction;

    private InputAction _uiLeftWeaponChangeInputAction;
    private InputAction _uiRightWeaponChangeInputAction;
    private InputAction _uiUnpauseInputAction;

    private void Awake()
    {
        Instance = this;

        PlayerInput = GetComponent<PlayerInput>();

        SetupInputActions();
    }
    private void Update()
    {
        UpdateInputs();
    }
    public void SetupInputActions()
    {
        _dirInputAction = PlayerInput.actions["Movement"];
        _jumpInputAction = PlayerInput.actions["Jump"];
        _dashInputAction = PlayerInput.actions["Dash"];
        _attackInputAction = PlayerInput.actions["Primary"];
        _specialInputAction = PlayerInput.actions["Secondary"];
        _leftWeaponChangeInputAction = PlayerInput.actions["LeftWeaponChange"];
        _rightWeaponChangeInputAction = PlayerInput.actions["RightWeaponChange"];
        _pauseInputAction = PlayerInput.actions["Pause"];

        _uiLeftWeaponChangeInputAction = PlayerInput.actions["UILeftWeaponChange"];
        _uiRightWeaponChangeInputAction = PlayerInput.actions["UIRightWeaponChange"];
        _uiUnpauseInputAction = PlayerInput.actions["UnPause"];
    }
    public void UpdateInputs()
    {
        UpdateFullPerformanceInput(ref Jump_Input_Pressed, ref Jump_Input_Hold, ref Jump_Input_Released, _jumpInputAction);
        UpdateFullPerformanceInput(ref Dash_Input_Pressed, ref Dash_Input_Hold, ref Dash_Input_Released, _dashInputAction);
        UpdateFullPerformanceInput(ref Attack_Input_Pressed, ref Attack_Input_Hold, ref Attack_Input_Released, _attackInputAction);
        UpdateFullPerformanceInput(ref Special_Input_Pressed, ref Special_Input_Hold, ref Special_Input_Released, _specialInputAction);
        UpdateSimpleValueInput(ref LeftWeaponChange_Pressed, _leftWeaponChangeInputAction);
        UpdateSimpleValueInput(ref RightWeaponChange_Pressed, _rightWeaponChangeInputAction);
        UpdateSimpleValueInput(ref UIRightWeaponChange_Pressed, _uiRightWeaponChangeInputAction);
        UpdateSimpleValueInput(ref UILeftWeaponChange_Pressed, _uiLeftWeaponChangeInputAction);
        UpdateSimpleValueInput(ref Pause_Input_Pressed, _pauseInputAction);
        UpdateSimpleValueInput(ref UI_Pause_Input_Pressed, _uiUnpauseInputAction);
        UpdateMoveInput();
    }
    public void UpdateFullPerformanceInput(ref bool pressed, ref bool held, ref bool release, InputAction action)
    {
        pressed = action.WasPressedThisFrame();
        held = action.IsPressed();
        release = action.WasReleasedThisFrame();
    }
    public void UpdateSimpleValueInput(ref bool pressed, InputAction action)
    {
        pressed = action.WasPressedThisFrame();
    }
    public void UpdateMoveInput()
    {
        MoveInput = _dirInputAction.ReadValue<Vector2>();
        if(MoveInput.x != 0)
        {
            MoveInput.x = MoveInput.x > 0 ? 1 : -1;
        }
        if (MoveInput.y != 0)
        {
            MoveInput.y = MoveInput.y > 0 ? 1 : -1;
        }
    }
}
