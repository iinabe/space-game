using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb; // изменяем тип переменной на Rigidbody2D

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // изменяем GetComponent на Rigidbody2D
        rb.velocity = transform.up * speed; // используем transform.up вместо transform.forward
    }

    private void OnCollisionEnter2D(Collision2D collision) // Изменяем OnCollisionEnter на OnCollisionEnter2D
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        // дополнительные действия при взрыве ракеты
        Destroy(gameObject);
    }
}
