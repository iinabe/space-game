using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageOnCollision : MonoBehaviour
{
    private GameSettings gameSettings;

    private void Awake()
    {
        gameSettings = FindObjectOfType<GameSettings>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DamageTarget(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DamageTarget(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void DamageTarget(GameObject target)
    {
        HpController hpController = target.GetComponent<HpController>();
        if (hpController != null)
        {
            int damage = 0;

            if (gameObject.CompareTag("Asteroid"))
            {
                damage = gameSettings.damages.AsteroidDamage;
            }
            else if (gameObject.CompareTag("Bullet"))
            {
                damage = gameSettings.damages.BulletDamage;
            }

            hpController.MakeDamage(damage);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}