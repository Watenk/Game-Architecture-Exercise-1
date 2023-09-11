using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridGenerationSettings", menuName = "ScriptableObjects/Settings/GridGenerationSettings")]
public class GridGenerationSettings : ScriptableObject
{
    public float WallAmount;
    public float EnemyAmount;
}