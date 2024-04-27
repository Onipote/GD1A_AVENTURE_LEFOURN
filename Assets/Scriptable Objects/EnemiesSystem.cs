using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesSystem : MonoBehaviour
{
    public float health;
    public float maxHealth;
    //public FloatValue maxHealth;
    public int Hp
    {
        get => health;
        private set
        {
            var isDamage = value < health;
            health = Mathf.Clamp(value, min:0, maxHealth);
            
            if (isDamage)
            {
                Damaged.Invoke(health);
            }
            else
            {
                Healed.Invoke(health);
            }
            if (health <= 0)
            {
                Died.Invoke();
            }
        }
    }

    public UnityEvent<int> Healed;
    public UnityEvent<int> Damaged;
    public UnityEvent<int> Died;

    private void Awake()
    {
        //health = maxHealth.initialValue;
        health = maxHealth;
    }

    public void Damage(int amount) => health -= amount;
    public void Heal(int amount) => health += amount;
    public void HealFull() => health = maxHealth;
    public void Kill() => health = 0;
    public void Adjust(int value) => health = value;
}
