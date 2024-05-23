using UnityEngine;

public class SlowDownObstacle : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Во сколько раз замедляется игрок
    public float slowDownDuration = 2f; // Длительность замедления в секундах

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SimpleUIInput playerController = other.GetComponent<SimpleUIInput>();
            if (playerController != null)
            {
                playerController.SlowDown(slowDownFactor, slowDownDuration);
            }
        }
    }
}
