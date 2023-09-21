using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class ActorBase : MonoBehaviour, IMovable, IDamagable
{
    [field: SerializeField]
    public float MaxHealth { get; set; }
    public float Health { get; set; }
    public Rigidbody2D rb {  get; set; }

    public delegate void ActorDied(GameObject actorInstance);
    public event ActorDied OnDied;

    protected StateMachine movementSM;

    public virtual void Start()
    {
        movementSM = new StateMachine();
        if (GetComponent<Rigidbody2D>())
        {
            rb = GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.LogError(this.name + " Has No RigidBody2D");
        }
        Health = MaxHealth;
    }

    //////////////////////////////////////////////////////////////////////////

    public virtual void Update()
    {
        movementSM.OnUpdate();
    }

    //////////////////////////////////////////////////////////////////////////

    //Interfaces
    //IMovable
    public virtual void Move(Vector2 Direction)
    {
        rb.AddForce(Direction);
    }

    //IDamagable
    public virtual void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        OnDied(this.gameObject);
    }
}
