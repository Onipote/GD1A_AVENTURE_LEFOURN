using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public GameObject player;

    public int currentHealthPlayer;
    public int maxHealthPlayer = 100;
    //private int shield = 50;

    //public int currentHealthMonster;
    //public int maxHealthMonster;

    private int damageFromMonster;
    private int damageFromBoss;

    void Start()
    {
        currentHealthPlayer = maxHealthPlayer;
        //currentHealthMonster = maxHealthMonster;
    }
}