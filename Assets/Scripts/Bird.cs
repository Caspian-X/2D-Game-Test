using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;

    public float increment;

    public int Direction { get; private set; } //1 = right, -1 = left
    public int Score { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Direction = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (rb.velocity.y < 0)
                rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * rb.mass * 12, ForceMode2D.Impulse);
            if (rb.velocity.y > 20)
                rb.velocity = new Vector2(rb.velocity.x, 20);
        }

        gameObject.transform.position += gameObject.transform.right * Direction * increment;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Direction *= -1;
            Vector3 scale = gameObject.transform.localScale;
            scale.x *= -1;
            gameObject.transform.localScale = scale;
        }

        if (collision.gameObject.tag == "Coin")
        {
            Score++;
        }
    }
}
