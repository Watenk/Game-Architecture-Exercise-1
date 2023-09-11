using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : Tile
{
    public Vector2Int Pos;
    public Vector2Int Size;

    public GridTile(int id, GameObject sprite, Vector2Int pos, Vector2Int size) : base(id, sprite)
    {
        Pos = pos;
        Size = size;
    }
}