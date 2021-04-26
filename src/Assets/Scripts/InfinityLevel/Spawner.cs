using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] obstaclePatterns;

    public Player player;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;

    private void Update()
    {
        if (timeBtwSpawn <= 0 && player.health > 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if( startTimeBtwSpawn > minTime) startTimeBtwSpawn -= decreaseTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
