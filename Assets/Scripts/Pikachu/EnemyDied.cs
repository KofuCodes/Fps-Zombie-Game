using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDied : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public WaveSpawner waveSpawner2;
    public WaveSpawner waveSpawner3;
    public WaveSpawner waveSpawner4;
    public WaveSpawner waveSpawner5;

    void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    void OnDestroy()
    {
        //waveSpawner.EnemyDied();
    }
}