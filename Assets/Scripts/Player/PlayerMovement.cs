using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void fixedUpdate(Player player) {
        rb.MovePosition(rb.position + player.movement * player.SPEED * Time.fixedDeltaTime);
    }
}
