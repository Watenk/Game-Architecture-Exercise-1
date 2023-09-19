using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData
{
    public GameObject TilePrefab;
    public float MaxHealth;

    public TileData(GameObject tilePrefab, float maxHealth)
    {
        TilePrefab = tilePrefab;
        MaxHealth = maxHealth;
    }
}