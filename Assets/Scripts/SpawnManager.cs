using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;
    public GameObject healthPrefab;

    //enemy spawn random location
    private float spawnRangeX = 25;
    private float spawnPosZ = 25;
    private float startDelayEnemy = 1;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelayEnemy, spawnInterval);
        InvokeRepeating("SpawnHealth", startDelayEnemy, 4);
    }

    

    void SpawnEnemy()
    {
        float distance = Random.Range(10, spawnRangeX);
        float direction = Random.Range(-1, 1);
        //Randomly generate enemy index and spawn position
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Vector3 spawnPos = new Vector3(distance * direction, .5f, Random.Range(10, spawnPosZ));

        Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
    }

    void SpawnHealth()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), .5f, Random.Range(0, spawnPosZ));
        Instantiate(healthPrefab, spawnPos, healthPrefab.transform.rotation);

    }

    public void EndGame()
    {
        CancelInvoke();
    }


    public void Reset()
    {
        Start();
    }

}
