using UnityEngine;
using UnityEngine.InputSystem;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public float explosionRadius = 5f;

    private GameSettings gameSettings;

    private void Awake()
    {
        gameSettings = FindObjectOfType<GameSettings>();
    }

    public void LaunchRocket(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
            Destroy(rocket, 5f);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    collider.gameObject.GetComponent<HpController>()?.MakeDamage(gameSettings.damages.RocketDamage);
                }
            }
        }
    }
}