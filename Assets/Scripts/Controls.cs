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
    public InputAction playerControls;

    [Header("Layers")]
    private bool isTouchingLayers;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rgbd.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}