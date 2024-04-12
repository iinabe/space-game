using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour
{

    Rigidbody2D rb;
    public int damage;
    //переменная величины силы
    public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 directon = new Vector3(0, force, 0);
        rb.AddForce(directon, ForceMode2D.Impulse);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //проверяем на тэг Enemy
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SendMessage("MakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}