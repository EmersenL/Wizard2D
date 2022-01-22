using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Camera cam;
    public ScreenBounds screenBounds;

    // public Vector2 playerPos;
    private Vector2 moveDirection;
    public Vector2 mousePos;

    // imported GameManager
    public Health HealthScript;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Move();

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }

    void GetInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        // playerPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Move()
    {
        // Vector3 tempPos = new Vector3(3, 3, 0);
        // Vector3 tempVel = new Vector3(moveDirection.x * speed, moveDirection.y * speed);
        if (screenBounds.AmIOutOfBounds(transform.position))
        {
            Vector2 newPosition = screenBounds.CalculateWrappedPosition(transform.position);
            transform.position = newPosition;
            // rb.velocity = tempVel;
        }
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            HealthScript.TakeDamage(10);
        }
    }
    */
}
