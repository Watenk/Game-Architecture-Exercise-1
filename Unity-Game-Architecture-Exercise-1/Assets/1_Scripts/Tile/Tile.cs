using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : IDamagable
{
    public Vector2Int Pos;
    public Vector2Int Size;
    public TileSettingsData TileData;
    public float Health { get; set; }

    public Tile(Vector2Int pos, Vector2Int size, TileSettingsData tileData)
    {
        Pos = pos;
        Size = size;
        TileData = tileData;
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
        //Replace Tile with 
    }
}
