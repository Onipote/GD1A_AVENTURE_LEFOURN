using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    public GameObject kindVillager;
    private int prixPotion = 3;

    void Update()
    {
        //Conversion du int en texte
        coinText.text = "Coquillage x" + coinCount.ToString();

        //Achat de la potion de regen
        if (coinCount == prixPotion)
        {
            coinCount -= prixPotion;
            Debug.Log("Tiens, voici la potion que tu souhaitais.");
        }
    }
}
