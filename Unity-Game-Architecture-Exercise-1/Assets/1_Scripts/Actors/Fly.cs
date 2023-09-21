using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : ActorBase
{
    public Fly(float maxHealth, System.Type startMovementState, IState[] movementStates) : base(maxHealth, startMovementState, movementStates)
    {

    }
}
