using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    private float timer = 0;
    [SerializeField] float spawnRate = 5;
    [SerializeField] int spawnAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= spawnRate && spawnAmount > 0)
        {
            timer = 0;
            Instantiate(spawnObject, transform.position, transform.rotation);
            spawnAmount--;
        }
    }
}
