using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorThrowingSystem : MonoBehaviour
{
    public Transform anchorSpawnPoint;
    public GameObject anchorPrefab;
    public float anchorSpeed = 10;

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            var anchor = Instantiate(anchorPrefab, anchorSpawnPoint.position, anchorSpawnPoint.rotation);
            anchor.GetComponent<Rigidbody2D>().velocity = anchorSpawnPoint.up * anchorSpeed;
        }
    }
}
