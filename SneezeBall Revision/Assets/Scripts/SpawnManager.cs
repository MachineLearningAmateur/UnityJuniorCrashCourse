using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float zBound = 10f;
    private int[] xChoice = {-22, 22};
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    bool spawn = true;
    float enemySpawnTimer = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating("spawnEnemy", 2.0f, enemySpawnTimer);
      InvokeRepeating("spawnPowerup", 2.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawn)
        {
            CancelInvoke();
        }
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPos(), enemyPrefab.transform.rotation);
        if (enemySpawnTimer > 3.0)
        {
            enemySpawnTimer = enemySpawnTimer - .01f;
        }
    }

    void spawnPowerup()
    {
        Instantiate(powerupPrefab, spawnPosP(), powerupPrefab.transform.rotation);
    }
    Vector3 spawnPos()
    {
        return new Vector3(xChoice[Random.Range(0,2)], 1, Random.Range(-zBound, zBound));
    }

    Vector3 spawnPosP()
    {
        return new Vector3(Random.Range(-10f, 10f), 1, Random.Range(-zBound, zBound));
    }

    public void SpawnOff()
    {
        spawn = false;
    }
}
