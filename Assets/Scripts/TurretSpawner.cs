using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSpawner : MonoBehaviour
{
    public Transform BottomRightPosition;
    public Transform LeftPosition;
    public Transform TopPosition;
    public Transform BottomPosition;
    public static TurretSpawner instance;


    public float spawnDelay;
    public turretScript Item;
    private int maxTurrets = 3;
    private int turretCount = 0;

    void Start()
    {
        instance = this;
        //BottomPosition.position = new Vector3(BottomPosition.position.x, Random.Range(1, 10) + 5);
        InvokeRepeating("CheckAndSpawn", spawnDelay, spawnDelay);
    }

    void CheckAndSpawn()
    {
        if (turretCount < maxTurrets)
        {
            Debug.Log("Spawning new turret...");
            float randomXPos = Random.Range(LeftPosition.position.x, BottomRightPosition.position.x);
            float randomYPos = Random.Range(TopPosition.position.y, BottomPosition.position.y);
            Vector3 spawnPos = new Vector3(randomXPos, randomYPos, 0);

            // ���������, ��� ������� ������ �� ������ ������ �������
            bool isPositionOccupied = false;
            foreach (var otherTurret in FindObjectsOfType<turretScript>())
            {
                if (otherTurret.transform.position == spawnPos)
                {
                    isPositionOccupied = true;
                    break;
                }
            }


            // ���� ������� ������ ������, ���������� ����� �������
            if (isPositionOccupied)
            {
                CheckAndSpawn();
                return;
            }

            var turret = Instantiate(Item, spawnPos, transform.rotation);
            turret.OnDie += TurretDestroyed;
            turretCount++;
        }
    }


    public void TurretDestroyed(turretScript turrel)
    {
        Debug.Log("Turret Destroyed!");
        turrel.OnDie -= TurretDestroyed;
        turrel.Die();
        turretCount--;

        if (turretCount < maxTurrets)
        {
            Debug.Log("Spawning new turret after destruction...");
            EventSystem.current.SetSelectedGameObject(null); // ����� �������� ���������� ������� � EventSystem (��� �������������� ������������ �������)
            CheckAndSpawn(); // �������� ������� ��� ������ ����� ������
        }
    }
}