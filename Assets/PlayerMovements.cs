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
        Debug.Log(change);

        if (change != Vector3.zero)
        {
            MoveCharacter();
        }

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
    }

    void MoveCharacter()
    {
        myRigidbody2D.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
