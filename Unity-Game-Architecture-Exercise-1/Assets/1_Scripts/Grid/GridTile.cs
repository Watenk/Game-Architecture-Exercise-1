using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile 
{
    public Vector2Int Pos { get; private set; }
    public Vector2Int Size { get; private set; }
    public GridSprite Sprite { get; private set; }

    public GridTile(Vector2Int pos, Vector2Int size, GridSprite sprite)
    {
        Pos = pos; 
        Size = size;
        Sprite = sprite;
    }
}