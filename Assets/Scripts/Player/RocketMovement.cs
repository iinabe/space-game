using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    private GameSettings gameSettings;
    Rigidbody2D rb;

    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        rb = GetComponent<Rigidbody2D>(); 
        rb.velocity = transform.up * gameSettings.movements.RocketSpeed; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
