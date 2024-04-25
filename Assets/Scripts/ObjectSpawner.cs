using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public Transform RightPosition;
    public float spawnDelay;
    public GameObject Item;
    private int meteoriteCount = 0; 
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime; 
        if (timer >= spawnDelay && meteoriteCount < 10) 
        {
            Spawn(); 
            timer = 0f; 
        }
    }

    void Spawn()
    {
        if (meteoriteCount < 10) 
        {
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x, RightPosition.position.x), transform.position.y, 0);
            Instantiate(Item, spawnPos, transform.rotation);
            meteoriteCount++; 
        }
        else
        {
           enabled = false;  
        }
    }
}