using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidDamage : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HpController hpController = other.gameObject.GetComponent<HpController>();
        if (hpController != null)
        {
            hpController.MakeDamage(damage); 
        }
        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Destroy(gameObject);
        }
    }
}