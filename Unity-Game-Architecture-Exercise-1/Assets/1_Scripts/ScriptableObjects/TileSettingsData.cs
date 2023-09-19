using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileSettingsData
{
    public int Id;
    public GameObject SpriteObject;
    public float MaxHealth;

    public TileSettingsData(int id, GameObject spriteObject, float maxHealth)
    {
        Id = id;
        SpriteObject = spriteObject;
        MaxHealth = maxHealth;
    }
}