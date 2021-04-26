using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 2;
    public float speedForward;
    public float speedVertical;

    public float maxHeight;
    public float minHeight;

    public GameObject effect;

    private void Start()
    {
        int rand = Random.Range(-1, 1);
        speedVertical *= rand;
        if (rand == 0) speedForward *= 2;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speedForward * Time.deltaTime);
        transform.Translate(Vector2.up * speedVertical * Time.deltaTime);
        if(transform.position.y > maxHeight) speedVertical = speedVertical * -1;
        else if (transform.position.y < minHeight) speedVertical = speedVertical * -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Instantiate(effect, transform.position, Quaternion.identity);
            collision.GetComponent<Player>().health -= damage;
            Debug.Log(collision.GetComponent<Player>().health);
            //Destroy(gameObject);
        }
    }
}
