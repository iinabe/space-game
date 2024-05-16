using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageOnCollision : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DamageTarget(other.gameObject);
        }
        Destroy(gameObject);
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
            hpController.MakeDamage(damage);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}