using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RoomMove : MonoBehaviour
{
    //Systeme de petite transition (sans changement de scene)
    //Pour l'acces aux "sous-parties" d'une zone

    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam; //Ref au script CameraMovement.cs

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
