using UnityEngine;

public class SlowDownObstacle : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Во сколько раз замедляется игрок
    public float slowDownDuration = 2f; // Длительность замедления в секундах

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object entered the trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the slow down zone");
            SimpleUIInput playerController = other.GetComponent<SimpleUIInput>();
            if (playerController != null)
            {
                Debug.Log("Applying slow down effect to player");
                playerController.SlowDown(slowDownFactor, slowDownDuration);
            }
            else
            {
                Debug.LogWarning("Player does not have a SimpleUIInput component");
            }
        }
        else
        {
            Debug.Log("The object is not the player");
        }
    }
}
