using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;
    private BoxCollider2D boxCollider;

    public GameObject iconEKey;
    public GameObject iconHideEye;
    public GameObject redArrow;

    public bool canHide = false;
    private bool hiding = false;

    private float positionXHide = 0;
    private float positionYHide = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        boxCollider = GetComponent<BoxCollider2D>();

        iconEKey.SetActive(false);
        iconHideEye.SetActive(false);
        redArrow.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canHide && !hiding)
            {
                boxCollider.enabled = !boxCollider.enabled;
                iconEKey.SetActive(true);
                iconHideEye.SetActive(true);
                redArrow.SetActive(true);
                hiding = true;
                transform.position = new Vector2(positionXHide, positionYHide);
            }
            else if (hiding)
            {
                redArrow.SetActive(false);
                boxCollider.enabled = !boxCollider.enabled;
                hiding = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hidingPlace = collision.gameObject;

        if (hidingPlace.tag.Equals("HidingPlace"))
        {
            iconEKey.SetActive(true);
            iconHideEye.SetActive(true);
            SetPositionToHide(hidingPlace);
            canHide = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject hidingPlace = collision.gameObject;

        if (hidingPlace.tag.Equals("HidingPlace"))
        {
            canHide = false;
            iconEKey.SetActive(false);
            iconHideEye.SetActive(false);
            redArrow.SetActive(false);
        }
    }

    public void SetPositionToHide(GameObject hide) 
    {
        positionXHide = hide.transform.position.x;
        positionYHide = hide.transform.position.y;
    }
}
