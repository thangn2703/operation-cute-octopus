using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject enemy;
    public GameObject star;

    //public int probabilityToSpawnStar;
    //public int probabilityToSpawnEnemy;

    void Start()
    {
        int rand = Random.Range(0, 100);
        if(rand < 10) Instantiate(star, transform.position, Quaternion.identity);
        else if(rand > 100 - 10) Instantiate(enemy, transform.position, Quaternion.identity);
        else Instantiate(obstacle, transform.position, Quaternion.identity);
    }
}
