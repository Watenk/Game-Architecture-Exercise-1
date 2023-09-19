using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IDamagable
{
    public float Health { get; set; }

    public Vector2Int Pos 
    { 
        get { return Pos; }
        set 
        {
            gameObject.transform.position = new Vector3(value.x, -value.y, 0);
        }
    }

    public Vector2Int Size;

    public float MaxHealth;

    public Tile(Vector2Int pos, Vector2Int size, float maxHealth)
    {
        Pos = pos;
        Size = size;
        MaxHealth = maxHealth;
    }

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
        Debug.Log("Tile Died (Need To Implement)");
    }
}
