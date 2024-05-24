using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorKitMove : MonoBehaviour
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
        transform.position = initialPosition;
        Vector3 move = new Vector3(0, -1, 0);
        rb.velocity = move * speed;

    }
}