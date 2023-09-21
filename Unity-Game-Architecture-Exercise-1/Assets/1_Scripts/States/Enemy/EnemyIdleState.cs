using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IState
{
    public StateMachine StateOwner { get; set; }

    public void SetOwner(StateMachine stateOwner)
    {
        StateOwner = stateOwner;
    }

    public void OnStart()
    {
    }

    public void OnUpdate()
    {
    }

    public void OnExit()
    {
    }
}
