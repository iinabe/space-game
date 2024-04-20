using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public float explosionRadius = 5f;

    public void LaunchRocket(InputAction.CallbackContext context)
    {
       // if (context.performed)
        {
            Debug.Log("Rocket launched!"); // ƒобавл€ем отладочное сообщение о запуске ракеты

            GameObject rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
            Destroy(rocket, 5f); // ”ничтожить ракету через 5 секунд

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius); 
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) 
                {
                    Debug.Log("Enemy hit! Destroying enemy...");
                    Destroy(collider.gameObject);
                }
            }
        }
    }
}
