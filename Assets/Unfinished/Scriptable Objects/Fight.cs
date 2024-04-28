using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private int currentHealthPlayer;
    //private int shield = 50;

    //public int currentHealthMonster;
    //public int maxHealthMonster;

    private int damageFromMonster;
    private int damageFromBoss;

    void Start()
    {
        currentHealthPlayer = (int)playerHealth.maxHealth;
        //currentHealthMonster = maxHealthMonster;
    }
}