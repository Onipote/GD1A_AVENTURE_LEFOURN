using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    //Mort d'ennemi/obstacles => drop d'items
    public GameObject lootMonster;
    public GameObject lootPrefab;
    public GameObject loot2Prefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Instantiate(lootMonster, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Rock"))
        {
            Instantiate(lootPrefab, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("TrainingDummy"))
        {
            Instantiate(lootPrefab, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("SpecialTrainingDummy"))
        {
            Instantiate(loot2Prefab, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    private void OnEnable()
    {
        Invoke("Shutdown", 0.5f);
    }

    private void Shutdown()
    {
        gameObject.SetActive(false);
    }
}
