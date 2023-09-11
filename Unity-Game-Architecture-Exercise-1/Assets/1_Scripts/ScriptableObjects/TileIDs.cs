using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "TileIDs", menuName = "ScriptableObjects/Settings/TileIDs")]
public class TileIDs : ScriptableObject
{
    public Tile Floor;
    public Tile Wall;
}
