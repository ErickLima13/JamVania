using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthStateMachine 
{
    public EarthState CurrentState
    {
        get; private set;
    }

    public void Initialize(EarthState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(EarthState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
