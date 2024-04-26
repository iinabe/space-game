using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSpawner : MonoBehaviour
{
    public Transform BottomRightPosition;
    public Transform LeftPosition;
    public Transform TopPosition;
    public Transform BottomPosition;

    public float spawnDelay;
    public GameObject Item;
    private int maxTurrets = 3;
    private int turretCount = 0;

    void Start()
    {
        InvokeRepeating("CheckAndSpawn", spawnDelay, spawnDelay);
    }

    void CheckAndSpawn()
    {
        if (turretCount < maxTurrets)
        {
            Vector3 spawnPos = new Vector3(Random.Range(LeftPosition.position.x, BottomRightPosition.position.x), Random.Range(BottomPosition.position.y, TopPosition.position.y), 0);
            Instantiate(Item, spawnPos, transform.rotation);
            turretCount++;
        }
    }

    public void TurretDestroyed()
    {
        turretCount--;
        if (turretCount < maxTurrets)
        {
            EventSystem.current.SetSelectedGameObject(null); // —брос текущего выбранного объекта в EventSystem (дл€ предотвращени€ срабатывани€ событий)
            CheckAndSpawn();
        }
    }
}

