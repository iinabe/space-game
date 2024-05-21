using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorKitSpawner : MonoBehaviour
{
    public Transform ArmorRightPosition;
    public float spawnDelay;
    public GameObject Item;
    private int armorkitCount = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnDelay && armorkitCount < 10)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        if (armorkitCount < 10)
        {
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x, ArmorRightPosition.position.x), transform.position.y, 0);
            Instantiate(Item, spawnPos, transform.rotation);
            armorkitCount++;
        }
        else
        {
            enabled = false;
        }
    }
}
