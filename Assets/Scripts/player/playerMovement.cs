using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private const float speed = 64f;

    public Rigidbody2D rb;

    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * speed;
        movement.y = Input.GetAxisRaw("Vertical") * speed;

        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, movement.y);
    }

}
