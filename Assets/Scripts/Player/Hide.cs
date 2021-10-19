using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private BoxCollider2D boxColliderHidingPlace;

    public GameObject iconEKey;
    public GameObject iconHideEye;
    public GameObject redArrow;
    public GameObject masterMiniGames;

    public bool canHide = false;
    private bool hiding = false;

    private float positionXHide = 0;
    private float positionYHide = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        boxColliderHidingPlace = GetComponent<BoxCollider2D>();

        DisableIcons();
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
                ActivateOrDisableCollider(boxColliderHidingPlace);
                ActivateIcons();
                hiding = true;
                transform.position = new Vector2(positionXHide, positionYHide);
            }
            else if (hiding)
            {
                ActivateOrDisableCollider(boxColliderHidingPlace);
                DisableIcons();
                hiding = false;
                transform.position = new Vector2(positionXHide, positionYHide - 1);
            }
        }
    }

    //HEYYYYY agregue logica para cochar con enemigos y activar el minijuego. Atte el gracia
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

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("enter Enemy");
            masterMiniGames.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject hidingPlace = collision.gameObject;

        if (hidingPlace.tag.Equals("HidingPlace"))
        {
            DisableIcons();
            canHide = false;
        }

    }

    public void SetPositionToHide(GameObject hide) 
    {
        positionXHide = hide.transform.position.x;
        positionYHide = hide.transform.position.y;
    }

    private void ActivateIcons() 
    {
        iconEKey.SetActive(true);
        iconHideEye.SetActive(true);
        redArrow.SetActive(true);
    }

    private void DisableIcons() 
    {
        iconEKey.SetActive(false);
        iconHideEye.SetActive(false);
        redArrow.SetActive(false);
    }

    private void ActivateOrDisableCollider(BoxCollider2D boxCollider2D) 
    {
        boxCollider2D.enabled = !boxCollider2D.enabled;
    }
}
