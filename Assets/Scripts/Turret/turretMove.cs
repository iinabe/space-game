using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TurretMove : MonoBehaviour
{
    private Vector3 moveDirection;
    private Vector3 initialPosition;
    public Transform BottomPosition;
    private GameSettings gameSettings;
    Rigidbody2D rb;

    void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        initialPosition = transform.position;
        BottomPosition = TurretSpawner.instance.BottomPosition;
        rb = GetComponent<Rigidbody2D>();
        Vector3 move = new Vector3(0, -1, 0);
        rb.velocity = move * gameSettings.movements.TurretSpeed; 
    }


    void FixedUpdate()
    {
        if (transform.position.y <= BottomPosition.position.y)
        {
            rb.velocity = new Vector2(0,0);
        }
    }
}