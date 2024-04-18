using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    [Header("Details")]
    [SerializeField] private Rigidbody2D rgbd;
    public float moveSpeed = 5f;
    Vector2 moveDirection = Vector2.zero;
    public PlayerInputActions playerControls;
    [SerializeField] private InputAction move;
    [SerializeField] private InputAction fire;

    [Header("Layers")]
    private bool isTouchingLayers;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rgbd.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        
    }
}