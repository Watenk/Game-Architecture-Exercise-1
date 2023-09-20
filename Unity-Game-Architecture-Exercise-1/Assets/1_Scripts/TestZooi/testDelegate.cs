using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDelegate : MonoBehaviour
{
    public delegate void MyDelegate(Vector2Int pos);
    public MyDelegate enemyWave;

    public void Start()
    {
        enemyWave += SpawnRed;
        enemyWave += SpawnGreen;

        enemyWave(new Vector2Int(0, 0));
    }

    public void SpawnRed(Vector2Int pos)
    {
        Debug.Log("Red");
    }

    public void SpawnGreen(Vector2Int pos)
    {
        Debug.Log("Green");
    }
}
