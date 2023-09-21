using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    public StateMachine StateOwner { get; set; }

    public void SetOwner(StateMachine stateOwner)
    {
        StateOwner = stateOwner;
    }

    public void OnStart()
    {
        Debug.Log("Player Idle State");
    }

    public void OnUpdate()
    {
    }

    public void OnExit()
    {
    }
}
