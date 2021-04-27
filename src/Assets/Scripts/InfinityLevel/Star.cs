using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private int value = 1;
    private float speed;
    private Vector2 direction;
    //public GameObject effect;

    void Start() {
        direction = GameController.gameControllerInstance.GetDirection();
        speed = GameController.gameControllerInstance.GetSpeed();
    }

    private void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Instantiate(effect, transform.position, Quaternion.identity);
            GameController.gameControllerInstance.IncrementStars(value);
            Destroy(gameObject);
        }
    }

}
