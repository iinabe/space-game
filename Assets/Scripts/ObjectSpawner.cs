using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public Transform RightPosition;
    public float spawnDelay;
    public GameObject Item;
    private int meteoriteCount = 0; // Переменная для отслеживания количества созданных метеоритов
    
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    void Spawn()
    {
        if (meteoriteCount < 10) // Проверяем, не созданы ли уже 10 метеоритов
        {
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x, RightPosition.position.x), transform.position.y, 0);
            Instantiate(Item, spawnPos, transform.rotation);
            meteoriteCount++; // Увеличиваем счетчик созданных метеоритов
        }
        else
        {
            CancelInvoke("Spawn"); // Отменяем повторение, если создано 10 метеоритов
        }
    }
}