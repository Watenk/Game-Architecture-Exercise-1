using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData
{
    public GameObject TilePrefab;
    public float MaxHealth;
    public int Id;

    public TileData(GameObject _tilePrefab, float _maxHealth, int _id)
    {
        TilePrefab = _tilePrefab;
        MaxHealth = _maxHealth;
        Id = _id;
    }
}