using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideController : MonoBehaviour
{
    private CapsuleCollider2D capsuleColliderHidingPlace;

    [SerializeField] private GameObject iconEKey;
    [SerializeField] private GameObject iconHideEye;
    [SerializeField] private GameObject redArrow;
    [SerializeField] private GameObject masterMiniGames;

    private bool canHide = false;
    private Vector2 positionToHide = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        capsuleColliderHidingPlace = GetComponent<CapsuleCollider2D>();
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
                ActivateOrDisableCollider(capsuleColliderHidingPlace);
                ActivateIcons();
                player.isHiding = true;
                transform.position = positionToHide;
            }
            else if (player.isHiding)
            {
                ActivateOrDisableCollider(capsuleColliderHidingPlace);
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

        else if (collision.gameObject.tag.Equals("Enemy"))
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

    private void ActivateOrDisableCollider(CapsuleCollider2D capsuleCollider2D) 
    {
        capsuleCollider2D.enabled = !capsuleCollider2D.enabled;
    }
}
