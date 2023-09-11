using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    public int Id;
    public GameObject Sprite;

    public Tile(int id, GameObject sprite)
    {
        Id = id;
        Sprite = sprite;
    }

}
