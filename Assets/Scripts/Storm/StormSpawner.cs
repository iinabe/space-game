using UnityEngine;
using System.Collections;

public class StormSpawner : MonoBehaviour
{
    public Transform RightPosition;
    public float spawnDelay;
    public GameObject Item;
    private int stormCount = 0; 
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime; 
        if (timer >= spawnDelay && stormCount < 5) 
        {
            Spawn(); 
            timer = 0f; 
        }
    }

    void Spawn()
    {
        if (stormCount < 5) 
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