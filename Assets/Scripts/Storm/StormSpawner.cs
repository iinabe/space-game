using UnityEngine;
using System.Collections;

public class StormSpawner : MonoBehaviour
{
    public Transform RightPosition;
    public float spawnDelay = 15f; // Задержка между спаунами в секундах
    public GameObject Item;
    private int stormCount = 0; 
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime; 
        if (timer >= spawnDelay && stormCount < 2) 
        {
            Spawn(); 
            timer = 1f; 
        }
    }

    void Spawn()
    {
        if (stormCount < 2) 
        {
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x, RightPosition.position.x), transform.position.y, 0);
            Instantiate(Item, spawnPos, transform.rotation);
            stormCount++; 
        }
        else
        {
           enabled = false;  
        }
    }
}