using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorBase : MonoBehaviour, IMovable, IDamagable
{
    public float Health { get; set; }
    public float MaxHealth { get; private set; }

    private Rigidbody2D rb;

    public ActorBase(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void Awake()
    {
        if (GetComponent<Rigidbody2D>())
        {
            rb = GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.LogError(this.name + " Has no RigidBody2D");
        }
    }

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
