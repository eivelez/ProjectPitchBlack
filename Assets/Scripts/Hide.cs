using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;
    private bool canHide = false;
    private bool hiding = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canHide && Input.GetKey(KeyCode.E))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            spriteRenderer.sortingOrder = 0;
            hiding = true;
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            spriteRenderer.sortingOrder = 2;
            hiding = false;
        }
    }

    private void FixedUpdate()
    {
        if (hiding)
        {
            playerMovement.SPEED = 0f;
        }
        else 
        {
            playerMovement.SPEED = 5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("HidingPlace"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("HidingPlace"))
        {
            canHide = false;
        }
    }
}
