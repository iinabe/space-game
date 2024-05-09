using UnityEngine;
using System.Collections;

public class MedKitSpawner : MonoBehaviour
{
    public Transform MedRightPosition;
    public float spawnDelay;
    public GameObject Item;
    private int medkitCount = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnDelay && medkitCount < 10)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        if (medkitCount < 10)
        {
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x, MedRightPosition.position.x), transform.position.y, 0);
            Instantiate(Item, spawnPos, transform.rotation);
            medkitCount++;
        }
        else
        {
            enabled = false;
        }
    }
}