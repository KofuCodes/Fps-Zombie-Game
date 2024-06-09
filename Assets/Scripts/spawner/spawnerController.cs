using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] spawners;
    public float waveCooldown = 5f; // Set your desired cooldown time
    private int currentWave = 1;
    private bool isCooldown = false;

    void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        if (!isCooldown)
        {
            foreach (var spawner in spawners)
            {
                spawner.GetComponent<WaveSpawner>().spawnDelay /= 2;
            }

            Debug.Log("Wave " + currentWave + " started!");

            currentWave++;
        }
        else
        {
            Debug.Log("Wave is on cooldown.");
        }
    }

    void EndWave()
    {
        isCooldown = true;
        Invoke("ResetCooldown", waveCooldown);
    }

    void ResetCooldown()
    {
        isCooldown = false;
        StartWave();
    }

    void Update()
    {
        // Check if all enemies are dead
        if (AllEnemiesDead())
        {
            EndWave();
        }
    }

    bool AllEnemiesDead()
    {
        // Implement your logic to check if all enemies are dead
        // For example, you can use GameObject.FindGameObjectsWithTag and check their health/status.
        // Return true when all enemies are dead, and false otherwise.
        return true; // Placeholder, replace with your actual logic
    }
}
