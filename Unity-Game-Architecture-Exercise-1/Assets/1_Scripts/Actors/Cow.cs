using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : ActorBase
{
    public Cow(float maxHealth, System.Type startMovementState, IState[] movementStates) : base(maxHealth, startMovementState, movementStates)
    {

    }
}
