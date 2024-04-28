using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;
    List<HealthHeart> hearts = new List<HealthHeart>();

    //Effet des degats sur le systeme de coeurs
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDamaged -= DrawHearts;
    }

    private void Start()
    {
        DrawHearts();
    }
    public void DrawHearts()
    {
        ClearHearts();

        //Determiner le nombre total de coeurs selon maxHealth
        float maxHealthRemainder = playerHealth.maxHealth % 2;
        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);
        
        //Creation du nombre de coeurs necessaires
        for(int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0;i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        Debug.Log("instantiation " + newHeart.transform.localScale);
        newHeart.transform.SetParent(transform);
        Debug.Log("parentage " + newHeart.transform.localScale);
        newHeart.transform.localScale = Vector3.one;
        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
        Debug.Log("ajout " + newHeart.transform.localScale);
    }
    //Enleve les coeurs crees dans le canva
    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        hearts = new List<HealthHeart>();
    }
}