using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb; // �������� ��� ���������� �� Rigidbody2D

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� GetComponent �� Rigidbody2D
        rb.velocity = transform.up * speed; // ���������� transform.up ������ transform.forward
    }

    private void OnCollisionEnter2D(Collision2D collision) // �������� OnCollisionEnter �� OnCollisionEnter2D
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        // �������������� �������� ��� ������ ������
        Destroy(gameObject);
    }
}
