using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public FieldOfViewController fieldOfViewController;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private PlayerCollision playerCollision;
    [SerializeField] private HideController hideController;
    public Inventory inventory;
    public PlayerSprite playerSprite;
    [HideInInspector] public Vector2 movement;
    [HideInInspector] public bool isHiding;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerCollision = GetComponent<PlayerCollision>();
        playerCollision.Setup(this);
        hideController = GetComponent<HideController>();
        inventory = GetComponent<Inventory>();
        playerSprite = GetComponent<PlayerSprite>();
        isHiding = false;
        hideController.Setup(this);
    }

    // Update is called once per frame
    void Update()
    {
        playerInput.update(this);
        playerAnimator.update(this);
        hideController.update();
    }

    void FixedUpdate()
    {
        playerMovement.fixedUpdate(this);
    }
}
