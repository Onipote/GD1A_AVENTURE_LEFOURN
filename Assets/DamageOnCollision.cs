using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage();
        Debug.Log("aie !");
    }
}