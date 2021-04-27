using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private GameObject effect;

    private Vector2 direction;
    private float speed;

    void Start() {
        direction = GameController.gameControllerInstance.GetDirection();
        speed = GameController.gameControllerInstance.GetSpeed();
    }


    private void Update(){
            transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            GameController.gameControllerInstance.DecrementHealth(damage);
            Destroy(gameObject);
        }
    }
}
