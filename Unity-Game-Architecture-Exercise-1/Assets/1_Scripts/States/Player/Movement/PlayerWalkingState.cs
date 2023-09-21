using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : IState
{
    public StateMachine StateOwner { get; set; }

    public void SetOwner(StateMachine stateOwner)
    {
        StateOwner = stateOwner;
    }

    public void OnStart()
    {
        Debug.Log("Player Walking State");
    }

    public void OnUpdate()
    {
    }

    public void OnExit()
    {
    }
}
