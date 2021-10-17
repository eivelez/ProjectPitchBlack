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

    private float positionXHide = 0;
    private float positionYHide = 0;

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
        PlayerHides();
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

    private void PlayerHides() 
    {
        if (canHide && Input.GetKey(KeyCode.E))
        {
            Hides(true, 0);
            transform.position = new Vector2(positionXHide,positionYHide);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            Hides(false, 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject hidingPlace = other.gameObject;

        if (hidingPlace.tag.Equals("HidingPlace"))
        {
            SetPositionHide(other.gameObject);
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject hidingPlace = other.gameObject;

        if (hidingPlace.tag.Equals("HidingPlace"))
        {
            canHide = false;
        }
    }

    private void Hides(bool isHidden, int orderInLayer) 
    {
        Physics2D.IgnoreLayerCollision(8, 9, isHidden);
        spriteRenderer.sortingOrder = orderInLayer;
        hiding = isHidden;
    }

    private void SetPositionHide(GameObject hide) 
    {
        positionXHide = hide.transform.position.x;
        positionYHide = hide.transform.position.y;
    }
}
