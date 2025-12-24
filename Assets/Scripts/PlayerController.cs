using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float dropForce = 8f;
    private Rigidbody2D rb;
    private float fixedX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedX = transform.position.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BreakFloorBelow();
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(-Vector2.up * dropForce, ForceMode2D.Impulse);
        }
    }

    void LateUpdate()
    {
        transform.position = new Vector3(fixedX, transform.position.y, transform.position.z);
    }

    void BreakFloorBelow()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f);

        if (hit.collider != null && hit.collider.CompareTag("Floor"))
        {
            Destroy(hit.collider.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (collision.transform.position.y < transform.position.y)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}