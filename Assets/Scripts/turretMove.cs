using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TurretMove : MonoBehaviour
{
    private Vector3 moveDirection;
    private Vector3 initialPosition;
    public Transform BottomPosition;
    public float speed;
    Rigidbody2D rb;
    public int damage;
    //public List<Vector3> Direction = new List<Vector3>() {new Vector3(0, -1, 0), new Vector3(1, 0, 0), new Vector3(-1, 0, 0) }
    

void Start()
    {
        initialPosition = transform.position; // на старте(ботомпозишн сделать такой) сделать рандом.рэндж(20, 80)+20
        BottomPosition = TurretSpawner.instance.BottomPosition;
        rb = GetComponent<Rigidbody2D>();
        //var random = new Random();
        //int index = random.Next(Direction.Count);
        Vector3 move = new Vector3(0, -1, 0);
        //Vector3 move = new Vector3(1, 0, 0);
        //Vector3 move = new Vector3(-1, 0, 0);
        rb.velocity = move * speed;
    }


    void FixedUpdate()
    {
        if (transform.position.y <= BottomPosition.position.y)
        {
            rb.velocity = new Vector2(0,0);
        }
    }
}