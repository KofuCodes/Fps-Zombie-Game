using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float initialSpawnDelay = 2f;  // Initial delay between enemy spawns
    public float spawnDelay;  // This will be adjusted during gameplay

    private void Start()
    {
        spawnDelay = initialSpawnDelay;
        InvokeRepeating("SpawnEnemyWave", 0f, spawnDelay);
    }

    void SpawnEnemyWave()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}