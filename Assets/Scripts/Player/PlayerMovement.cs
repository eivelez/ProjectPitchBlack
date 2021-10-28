using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float SPEED = 5f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void fixedUpdate(Player player) {
        if (player.isHiding)
        {
            return;
        }

        rb.MovePosition(rb.position + player.movement * SPEED * Time.fixedDeltaTime);
    }
}
