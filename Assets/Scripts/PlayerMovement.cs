using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FieldOfViewController fieldOfViewController;
    public float SPEED = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector3 mousePos;
    private Vector2 movement;

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * SPEED * Time.fixedDeltaTime);

        Vector3 aimDir = (mousePos - transform.position).normalized;
        fieldOfViewController.SetAimDirection(aimDir);
        fieldOfViewController.SetOrigin(transform.position);
    }
}
