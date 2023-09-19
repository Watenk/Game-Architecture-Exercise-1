using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "TilesSettings", menuName = "ScriptableObjects/Settings/TilesSettings")]
public class TilesSettings : ScriptableObject
{
    public TileSettingsData Floor;
    public TileSettingsData Wall;
}
