using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridGenerationSettings", menuName = "ScriptableObjects/Settings/GridGenerationSettings")]
public class GridGenerationSettings : ScriptableObject
{
    public Vector2Int GridSize;
    public Vector2Int TileSize;

    public float WallAmount;
    public float EnemyAmount;
}