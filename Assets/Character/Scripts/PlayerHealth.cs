using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isTouched = false;
    private float timerIsTouched = 0f;
    public int damageReceived;

    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public float health, maxHealth;
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        //Frame d'invulnérabilité
        if (timerIsTouched > 0)
        {
            timerIsTouched -= Time.deltaTime;
            Debug.Log("Au secours..");
        }
        else
        {
            isTouched = false;
        }
    }

    public void TakeDamage()
    {
        if (!isTouched)
        {
            health -= damageReceived;
            OnPlayerDamaged?.Invoke();

            if (health <= 0)
            {
                health = 0;
                Debug.Log("You're dead.");
                OnPlayerDeath?.Invoke();
            }
            timerIsTouched = 1.5f;
            isTouched = true;
        }
    }
}
