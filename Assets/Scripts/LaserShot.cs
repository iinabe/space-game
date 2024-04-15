using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour
{
    public float speed = 10f;
    public int damage;
    public Vector2 direction;

    void Start()
    {
        // Направление движения лазера
        direction = transform.up;
    }

    void Update()
    {
        // Двигаем лазер по направлению с заданной скоростью
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.SendMessage("MakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}