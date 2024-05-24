using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MedKitMove : MonoBehaviour
{
    private Vector3 moveDirection;
    private Vector3 initialPosition;
    private GameSettings gameSettings;

    void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        initialPosition = transform.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 move = new Vector3(0, -1, 0);
        rb.velocity = move * gameSettings.movements.MedKitSpeed; 
    }

    void OnBecameInvisible()
    {
        transform.position = initialPosition;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 move = new Vector3(0, -1, 0);
        rb.velocity = move * gameSettings.movements.MedKitSpeed;
    }
}