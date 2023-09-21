using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ActorBase
{
    public Player(float maxHealth, System.Type startMovementState, IState[] movementStates) : base(maxHealth, startMovementState, movementStates)
    {

    }
}
