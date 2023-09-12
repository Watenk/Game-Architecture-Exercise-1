using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData
{
    public int Id;
    public GameObject SpriteObject;
    public float Health;
    public float DamageMultiplier;

    public TileData(int id, GameObject spriteObject, float health, float damageMultiplier)
    {
        Id = id;
        SpriteObject = spriteObject;
        Health = health;
        DamageMultiplier = damageMultiplier;
    }
}