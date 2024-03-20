using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [Header("Details")]
    [SerializeField] private KeyCode leftKey = KeyCode.A, rightKey = KeyCode.D, upKey = KeyCode.Z, downKey = KeyCode.S;
    [SerializeField] private Rigidbody2D rgbd;
    public float speed;
    [SerializeField] private BoxCollider2D boxCharacter;

    [Header("Layers")]
    private bool isTouchingLayers;
    private int groundMask;

    [Header("Variables")]
    private bool isGrounded = true;

    void Update()
    {
        if (isGrounded == true)
        {
            if (Input.GetKey(leftKey))
            {
                rgbd.AddForce(Vector2.left * speed);
            }
            if (Input.GetKey(rightKey))
            {
                rgbd.AddForce(Vector2.right * speed);
            }
            if (Input.GetKey(upKey))
            {
                rgbd.AddForce(Vector2.up * speed);
            }
            if (Input.GetKey(downKey))
            {
                rgbd.AddForce(Vector2.down * speed);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (boxCharacter.IsTouchingLayers(groundMask))
        {
            isGrounded = true;
        }
    }
}