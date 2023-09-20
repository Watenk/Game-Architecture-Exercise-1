using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IDamagable
{
    public Vector2Int Pos 
    { 
        get 
        { 
            return pos; 
        }
        set 
        {
            gameObject.transform.position = new Vector3(value.x, -value.y, 0);
            pos = value;
        }
    }
    public float Health { get; set; }
    public Vector2Int Size;
    public float MaxHealth;

    private Vector2Int pos;

    //Events
    public delegate void TileDied(Vector2Int pos);
    public event TileDied OnDied;

    ///////////////////////////////////////////////////////////////

    public Tile(Vector2Int pos, Vector2Int size, float maxHealth)
    {
        Pos = pos;
        Size = size;
        MaxHealth = maxHealth;
    }

    /////////////////////////////////////////////////////////////

    //IDamagable
    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDied(Pos);
    }
}
