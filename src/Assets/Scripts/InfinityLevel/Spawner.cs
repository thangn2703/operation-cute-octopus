using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] patterns;

    [SerializeField]
    private float interval;

    void Start() {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop() {
        while(GameController.gameControllerInstance.IsRunning()) {
            yield return new WaitForSeconds(interval);
            GameObject pattern = GetRandomPattern();
            SpawnObstacles(pattern);
        }
    }

    private GameObject GetRandomPattern() {
        int rand = Random.Range(0, patterns.Length);
        return patterns[rand];
    }

    private void SpawnObstacles(GameObject pattern) {
        Instantiate(pattern, transform.position, Quaternion.identity);
    }
}
