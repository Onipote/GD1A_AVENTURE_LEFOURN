using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collectibles : MonoBehaviour
{
    public BoxCollider2D boxCharacter;
    private bool isTouchingLayers;
    private int collectablesMask;

    public BoxCollider2D boxPlastic;
    public int compteurPlastic;
    void Start()
    {
        collectablesMask = LayerMask.GetMask("Collectables");
        compteurPlastic = 0;
    }

    void Update()
    {
        if (boxCharacter.IsTouchingLayers(collectablesMask))
        {
            Destroy(boxPlastic.gameObject);
            compteurPlastic += 1;
            Debug.Log("Piece of plastic x" + compteurPlastic);
        }
    }
}
