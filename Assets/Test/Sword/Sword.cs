using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerInputActions playerControls;
    private Animator myAnimator;

    public Vector2 PointerPosition { get; set; }

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        playerControls.Fight.Attack.started += _ => Attack();
    }

    private void Update()
    {
        //si pointeur de l'autre cote, flip l'arme
    }
    private void Attack()
    {
        myAnimator.SetTrigger("Attack");
    }
}
