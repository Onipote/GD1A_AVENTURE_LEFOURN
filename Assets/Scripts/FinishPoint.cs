using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Acces zone 002
            SceneController.instance.NextZone();
        }
    }
}
