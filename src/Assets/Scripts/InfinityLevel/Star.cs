using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int give = 1;
    public float speed;

    //public GameObject effect;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Instantiate(effect, transform.position, Quaternion.identity);
            collision.GetComponent<Player>().starCollection += give;
            Debug.Log(collision.GetComponent<Player>().starCollection);
            Destroy(gameObject);
        }
    }

}
