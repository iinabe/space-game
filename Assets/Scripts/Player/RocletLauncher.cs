using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public float explosionRadius = 5f;
    public int damage = 100;
    //GameSettings.Damages.rocketDamage;

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
                    collider.gameObject.SendMessage("MakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
