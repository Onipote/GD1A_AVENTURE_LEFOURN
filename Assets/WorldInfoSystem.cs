using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldInfoSystem : MonoBehaviour
{
    public GameObject textBox;
    public Text infoText;
    public string info;
    public bool playerInRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (textBox.activeInHierarchy)
            {
                textBox.SetActive(false);
            }
            else
            {
                textBox.SetActive(true);
                infoText.text = info;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            textBox.SetActive(false);
        }
    }
}
