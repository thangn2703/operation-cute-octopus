using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed

    private bool move = true;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (move == true && Vector2.Distance(transform.position, target.transform.position) < 3)
        {
            Vector3 targetDir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") == true)
        {
            IsShot();
        }

        if (collision.CompareTag("Player") == true)
        {
            Debug.Log("You're Dead, My Dude.");
        }
    }

    public void IsShot()
    {
        move = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

}
