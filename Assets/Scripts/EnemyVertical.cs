using UnityEngine;

public class EnemyVertical : MonoBehaviour
{
    private float dirX;
    public float moveSpeed = 32f;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Wall>())
        {
            dirX *= -1f;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, dirX * moveSpeed);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.y < 0)) || ((!facingRight) && (localScale.y > 0)))
            localScale.y *= -1;

        transform.localScale = localScale;
    }
}
