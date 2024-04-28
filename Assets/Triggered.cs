using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    public GameObject lootPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Rock"))
        {
            Instantiate(lootPrefab, collision.gameObject.transform.position, Quaternion.identity);
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
