using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Grid Settings")]
    public Vector2Int GridSize;
    public Vector2Int TileSize;
    public float WallAmount;
    public float EnemyAmount;

    [Header("Player Settings")]
    public float RayDamage;

    [Header("TileData")]
    public TileData Floor;
    public TileData Wall;
}
