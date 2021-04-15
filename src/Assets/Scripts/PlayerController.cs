using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float horizontalMoveSpeed = 1;
    [SerializeField]
    private float verticalMoveSpeed = 1;


    private Rigidbody2D rb2D;
    private Vector2 axis;

    // Start is called before the first frame update
    void Start(){
        rb2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate() {
        Move(axis);
    }

    public void OnMove(InputValue input) {
        axis = input.Get<Vector2>();
    }

    private void Move(Vector2 axis) {
        rb2D.AddForce(
                new Vector2(
                    axis.x * horizontalMoveSpeed - rb2D.velocity.x,
                    axis.y * verticalMoveSpeed - rb2D.velocity.y
                ),
                ForceMode2D.Impulse
            );
    }
}
