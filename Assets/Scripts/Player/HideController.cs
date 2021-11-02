using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideController : MonoBehaviour
{
    [SerializeField] private AudioClip hideSound;

    private CapsuleCollider2D capsuleColliderHidingPlace;

    private bool canHide = false;

    private Vector2 positionToHide = Vector2.zero;

    private Player player;



    // Start is called before the first frame update
    public void Setup(Player player)
    {
        this.player = player;
        capsuleColliderHidingPlace = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    public void update()
    {
        PlayerHides();
    }

    private void PlayerHides() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canHide && !player.isHiding)
            {
                ActivateOrDisableCollider(capsuleColliderHidingPlace);
                player.playerSprite.ShowHidingSprites();
                player.isHiding = true;
                transform.position = positionToHide;
                AudioSource.PlayClipAtPoint(hideSound, transform.position);
            }
            else if (player.isHiding)
            {
                ActivateOrDisableCollider(capsuleColliderHidingPlace);
                player.playerSprite.HideHidingSprites();
                player.isHiding = false;
                transform.position = positionToHide - new Vector2(0, 1);
                AudioSource.PlayClipAtPoint(hideSound, transform.position);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hidingPlace = collision.gameObject;

        if (hidingPlace.tag.Equals("HidingPlace"))
        {
            player.playerSprite.ShowHidingPromptSprites();
            SetPositionToHide(hidingPlace);
            canHide = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject hidingPlace = collision.gameObject;

        if (hidingPlace.tag.Equals("HidingPlace"))
        {
            player.playerSprite.HideHidingSprites();
            canHide = false;
        }

    }

    public void SetPositionToHide(GameObject hide) 
    {
        positionToHide = hide.transform.position;
    }

    private void ActivateOrDisableCollider(CapsuleCollider2D capsuleCollider2D) 
    {
        capsuleCollider2D.enabled = !capsuleCollider2D.enabled;
    }
}
