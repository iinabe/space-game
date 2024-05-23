using UnityEngine;

public class StormMove : MonoBehaviour
{
    private Vector3 initialPosition;
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Vector3 move = new Vector3(0, -1, 0);
        rb.velocity = move * speed;
    }

    void OnBecameInvisible()
    {
        transform.position = initialPosition;
        Vector3 move = new Vector3(0, -1, 0);
        rb.velocity = move * speed;
    }
}
