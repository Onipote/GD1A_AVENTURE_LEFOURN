using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InaccessibleAreaSystem : MonoBehaviour
{
    public GameObject player;
    private float distance;
    public bool isInRange;

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 5)
        {
            isInRange = true;
        }
    }

    private void Acces(bool)
    {
        if (isInRange == true)
        {
            Debug.Log("Vous ne passerez pas tant que vous en prouverez pas que vous �tre bien de la famille royale !");
        }
    }

    /*public bool isInRange;

    void Update()
    {
        if (isInRange == true)
        {
            Debug.Log("Vous ne passerez pas tant que vous en prouverez pas que vous �tre bien de la famille royale !");
        }
    }
    void OnTriggerEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    //Retour au Hub (le ch�teau, zone 1) si le collier n'a pas �t� pris au d�but du jeu
    void OnTriggerExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Je dois r�cup�rer le collier de M�re. C'est le bijoux le plus symbolique de notre famille.");
        }
    }

    {
        if (collision.gameObject.CompareTag("InaccessibleArea") /sans le collier)
        {
            Debug.Log("Vous ne passerez pas tant que vous en prouverez pas que vous �tre bien de la famille royale !");
        }

        //sinon
        //Destroy(barrage.gameObject);
    }*/
}