using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody2D;
    private Vector3 change;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (change != Vector3.zero)
        {
            MoveCharacter();
        }

        //Déplacements basiques (droite, gauche, haut, bas)
        if (change.x > 0)
        {
            gameObject.GetComponent<Animator>().Play("Walking_SideView_R");
        }
        /*else
        {
            gameObject.GetComponent<Animator>().Play("Walking_SideView_L");
        }*/
        if (change.y > 0)
        {
            gameObject.GetComponent<Animator>().Play("Walking_BackView");
        }
        if (change.y < 0)
        {
            gameObject.GetComponent<Animator>().Play("Walking_FrontView");
        }
        
        //Cibler avec le curseur
        

        //Attaque : coup de poing
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("FistAttack_SideView_R");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("FistAttack_SideView_L");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("FistAttack_BackView");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("FistAttack_FrontView");
        }
    }

    void MoveCharacter()
    {
        myRigidbody2D.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
