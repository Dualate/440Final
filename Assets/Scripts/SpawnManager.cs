using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;
    public GameObject[] coinPrefab;

    //enemy spawn random location
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelayEnemy = 1;
    private float startDelayCoin = 2;
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelayEnemy, spawnInterval);
        //InvokeRepeating("SpawnCoins", startDelayCoin, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        //Randomly generate enemy index and spawn position
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnPosZ, spawnPosZ));

        Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
    }

    void SpawnCoins()
    {
        //Randomly generate enemy index and spawn position
        int coinIndex = Random.Range(0, coinPrefab.Length);
        Vector3 randomSpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.2455f, Random.Range(-spawnPosZ, spawnPosZ));

        Instantiate(coinPrefab[coinIndex], randomSpawnPos, coinPrefab[coinIndex].transform.rotation);
    }

}
