using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSystem : MonoBehaviour
{
    public GameObject anchor;
    public float launchForce;
    public Transform shotPoint;

    void Update()
    {
        Vector2 anchorPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - anchorPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newAnchor = Instantiate(anchor, shotPoint.position, shotPoint.rotation);
        newAnchor.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}
