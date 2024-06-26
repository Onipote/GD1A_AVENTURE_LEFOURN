using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Chase : MonoBehaviour
{
    //Poursuite du joueur si celui-ci est entr�e dans une zone ennemie

    public GameObject player;
    public float speed;
    public float speedAttack;
    private float distance;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 5)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            anim.Play("(AwakenMonster)");

        }
        else if (distance < 3)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speedAttack * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            anim.Play("(AwakenMonster)");
        }
        else if (distance >= 5)
        {
            anim.Play("(AsleepMonster)");
        }
    }

}
