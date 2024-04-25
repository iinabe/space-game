using UnityEngine;
using System.Collections;

public class TurretSpawner : MonoBehaviour
{
    public Transform BottomRightPosition;
    public Transform LeftPosition;
    public Transform TopPosition;
    public Transform BottomPosition;


    public float spawnDelay;
    public GameObject Item;
    private int maxTurrets = 3; // ћаксимальное количество турелей
    private int turretCount = 0; // ѕеременна€ дл€ отслеживани€ количества созданных турелей

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    void Spawn()
    {
        if (turretCount < maxTurrets) // ѕровер€ем, не достигнуто ли максимальное количество турелей
        {
            Vector3 spawnPos = new Vector3(Random.Range(LeftPosition.position.x, BottomRightPosition.position.x), Random.Range(BottomPosition.position.y, TopPosition.position.y), 0);
            Instantiate(Item, spawnPos, transform.rotation);
            turretCount++; // ”величиваем счетчик созданных турелей
        }
    }
}