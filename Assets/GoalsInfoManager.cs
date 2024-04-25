using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalsInfoManager : MonoBehaviour
{
    public int coinCount;
    public Text goalText;

    void Update()
    {
        coinText.text = "Coquillage x" + coinCount.ToString();
    }
}
