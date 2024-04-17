using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSystem : MonoBehaviour
{
    [Header("Fight System")]
    [SerializeField] private BoxCollider2D player;
    private bool isTouchingLayers;
    private int angryVillagersMask;

    private bool isTouched = false;
    private float timerIsTouched = 0f;

    [Header("Heart System")]
    public int health;
    public int maxHealth = 100;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;


    private void Start()
    {
        angryVillagersMask = LayerMask.GetMask("AngryVillagers");

        health = maxHealth;
    }

    private void Update()
    {
        //Frame d'invulnérabilité
        if (timerIsTouched > 0)
        {
            timerIsTouched -= Time.deltaTime;
        }
        else
        {
            isTouched = false;
        }

        //Heart System
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si le joueur est rentré en contact la catégorie de villageois énervé
        if (player.IsTouchingLayers(angryVillagersMask) && !isTouched)
        {
            //TakeDamage(Random.Range(10, 25));
            Debug.Log("a pris des degats");
            isTouched = true;
            timerIsTouched = 2f;
        }
    }

    /*public void TakeDamage(float damage)
    {
        health -= (int)damage;
    }*/
}
