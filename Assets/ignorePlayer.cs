using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignorePlayer : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;

    private void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y);
        Debug.Log(transform.position);
    }

    private void OnCollisionEnter2D(Collision2D col2d)
    {
        if (col2d.collider.name == "AIWall")
        {
            Physics2D.IgnoreCollision(col2d.collider, col2d.otherCollider);
        }
    }
}