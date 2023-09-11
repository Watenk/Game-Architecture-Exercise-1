using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDelegate : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate enemyWave;

    public void Start()
    {
        enemyWave += SpawnRed;
        enemyWave += SpawnGreen;

        enemyWave();
    }

    public void SpawnRed()
    {
        Debug.Log("Red");
    }

    public void SpawnGreen()
    {
        Debug.Log("Green");
    }
}
