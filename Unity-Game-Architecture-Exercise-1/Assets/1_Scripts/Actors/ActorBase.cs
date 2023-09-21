using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorBase : IMovable, IDamagable
{
    public float Health { get; set; }
    public float MaxHealth { get; private set; }

    private Rigidbody2D rb;
    private StateMachine movementSM;

    public ActorBase(float maxHealth, System.Type startingMovementState, IState[] otherMovementStates)
    {
        MaxHealth = maxHealth;
        movementSM = new StateMachine();
        movementSM.AddStates(startingMovementState, otherMovementStates);
    }

    //////////////////////////////////////////////////////////////////////////

    public void OnUpdate()
    {
        movementSM.OnUpdate();
    }

    //////////////////////////////////////////////////////////////////////////

    //Interfaces
    //IMovable
    public void Move(Vector2 Direction, float strenght)
    {
        rb.AddForce(Direction * strenght);
    }

    //IDamagable
    public void TakeDamage(float damageAmount)
    {
    }

    public void Die()
    {
    }
}
