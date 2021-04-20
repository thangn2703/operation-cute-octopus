using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rigid;
    float xDirection;
    float movementSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.acceleration.x * movementSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7f, 7f), transform.position.y);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(xDirection, 0f);
    }
}
