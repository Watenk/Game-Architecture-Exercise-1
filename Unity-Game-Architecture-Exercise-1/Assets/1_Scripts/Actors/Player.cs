using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ActorBase
{
    public override void Start()
    {
        base.Start();
        IState[] playerStates =
        {
            new PlayerIdleState(),
            new PlayerWalkingState(),
        };
        movementSM.AddStates(typeof(PlayerIdleState), playerStates);
    }

    public override void Die()
    {
        Debug.Log("Player Died!!!");
    }
}
