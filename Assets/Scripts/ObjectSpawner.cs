using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public Transform RightPosition;
    public float spawnDelay;
    public GameObject Item;

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    //������� ������
    void Spawn()
    {
        //��������� ������� ����� ������� � ������ ��������
        Vector3 spawnPos = new Vector3(Random.Range(transform.position.x, RightPosition.position.x), transform.position.y, 0);
        Instantiate(Item, spawnPos, transform.rotation);
    }
}