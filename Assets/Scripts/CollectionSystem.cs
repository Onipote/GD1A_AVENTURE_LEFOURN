using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public List<string> inventory;
    private void Start()
    {
        inventory = new List<string>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            string itemType = collision.gameObject.GetComponent<CollectableScript>().itemType;
            print("We have collected a :" + itemType); 
            inventory.Add(itemType);
            print("Inventory length :" + inventory.Count);
            Destroy(collision.gameObject);
        }
    }
}