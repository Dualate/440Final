using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;


    //enemy spawn random location
    private float spawnRangeX = 40;
    private float spawnPosZ = 40;
    private float startDelayEnemy = 1;
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelayEnemy, spawnInterval);
    }

    

    void SpawnEnemy()
    {
        //Randomly generate enemy index and spawn position
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX) + 10, .5f, Random.Range(-spawnPosZ, spawnPosZ) + 10);

        Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
    }

    

}
