using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAlternative : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontal;
    float vertical;
    public float speed;
    Rigidbody2D rb;
    void Start()
    {
        speed = 2f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
