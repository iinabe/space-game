using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour
{

    Rigidbody2D rb;
    public int damage;
    public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = transform.up * force; // Новое направление по координатам
        rb.velocity = new Vector2(direction.x, direction.y); // Устанавливаем скорость по координатам
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SendMessage("MakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}