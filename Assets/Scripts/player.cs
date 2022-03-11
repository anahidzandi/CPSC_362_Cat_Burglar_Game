using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //Get Input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Debug.Log(x);
        //Debug.Log(y);

        //Reset moveDelta
        moveDelta = new Vector3(x,y,0);

        //Swap sprite direction
        if (moveDelta.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //y-collision
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            //Movement
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //x-collision
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            //Movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }
}
