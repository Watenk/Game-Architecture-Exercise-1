using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : IDamagable
{
    public Vector2Int Pos;
    public Vector2Int Size;
    public TileData TileData;
    public float Health { get; set; }

    public Tile(Vector2Int pos, Vector2Int size, TileData tileData)
    {
        Pos = pos;
        Size = size;
        TileData = tileData;
    }

    public void Die()
    {
        //Replace Tile with 
    }
}
