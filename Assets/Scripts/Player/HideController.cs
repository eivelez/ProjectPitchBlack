using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideController : MonoBehaviour
{
    private BoxCollider2D boxColliderHidingPlace;

    [SerializeField] private GameObject iconEKey;
    [SerializeField] private GameObject iconHideEye;
    [SerializeField] private GameObject redArrow;
    [SerializeField] private GameObject masterMiniGames;

    private bool canHide = false;
    private Vector2 positionToHide = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        boxColliderHidingPlace = GetComponent<BoxCollider2D>();
        DisableIcons();
    }

    // Update is called once per frame
    public void update(Player player)
    {
        PlayerHides(player);
    }

    private void PlayerHides(Player player) 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canHide && !player.isHiding)
            {
                ActivateOrDisableCollider(boxColliderHidingPlace);
                ActivateIcons();
                player.isHiding = true;
                transform.position = positionToHide;
            }
            else if (player.isHiding)
            {
                ActivateOrDisableCollider(boxColliderHidingPlace);
                DisableIcons();
                player.isHiding = false;
                transform.position = positionToHide - new Vector2(0, 1);
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
        positionToHide = hide.transform.position;
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
