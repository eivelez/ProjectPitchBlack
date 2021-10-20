using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FieldOfViewController fieldOfViewController;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerAnimator playerAnimator;
    public float SPEED = 5f;
    [HideInInspector] public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput.update(this);
        playerAnimator.update(this);
    }

    void FixedUpdate()
    {
        playerMovement.fixedUpdate(this);
    }
}
