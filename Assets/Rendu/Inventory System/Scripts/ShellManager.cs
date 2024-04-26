using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;

    void Update()
    {
        //Conversion du int en texte
        string v = "Coquillage x" + coinCount.ToString();
        coinText.text = v;
    }
}
