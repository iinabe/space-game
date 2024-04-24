using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AsteroidMove : MonoBehaviour
{
    private Vector3 moveDirection;
    private Vector3 initialPosition;
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Vector3 move = new Vector3(0, -1, 0);
        rb.velocity = move * speed;
    }

   void OnBecameInvisible()
    {
        // Перемещаем метеорит обратно в изначальное положение
        transform.position = initialPosition;
        // Продолжаем движение в том же направлении
       Vector3 move = new Vector3(0, -1, 0);
        rb.velocity = move * speed;

    }


   /*void OnCollisionEnter2D(Collision2D something)
    {
        if (something.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    } */
}