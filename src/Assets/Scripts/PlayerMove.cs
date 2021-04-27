using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rigid;
    float xDirection;
    public float movementSpeed = 20f;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        xDirection = Input.acceleration.x * movementSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), transform.position.y);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(xDirection, 0f);
    }
}
