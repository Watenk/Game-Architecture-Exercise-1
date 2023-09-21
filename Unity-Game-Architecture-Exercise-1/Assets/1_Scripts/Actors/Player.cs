using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ActorBase
{
    private float idleTimer;
    private float idleTimerAmount = 2;

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

    public override void Update()
    {
        base.Update();

        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            movementSM.SwitchState(typeof(PlayerIdleState));
        }
    }

    public override void Die()
    {
        Debug.Log("Player Died!!!");
    }

    public override void Move(Vector2 Direction)
    {
        movementSM.SwitchState(typeof(PlayerWalkingState));
        idleTimer = idleTimerAmount;
        rb.AddForce(Direction * 10);
    }
}
