using UnityEngine;
using System.Collections;

public class CoinsSpawner : MonoBehaviour
{
    public Transform CoinsPosition;
    public float spawnDelay;
    public GameObject Item;
    private int CoinsCount = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnDelay && CoinsCount < 10)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        if (CoinsCount < 10)
        {
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x, CoinsPosition.position.x), transform.position.y, 0);
            Instantiate(Item, spawnPos, transform.rotation);
            CoinsCount++;
        }
        else
        {
            enabled = false;
        }
    }
}