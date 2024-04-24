using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    public float shootingForce = 10f;
    public int destroyedMeteoriteCount = 0;

    private float shootInterval = 0.5f;
    private float shootTimer = 0f;

    void Update()
    {
        shootTimer += Time.deltaTime; // Увеличиваем время прошедшее с момента последнего выстрела
        if (shootTimer >= shootInterval) // Если прошло время, больше или равное интервалу между выстрелами
        {
            ShootLaser(); // Стреляем лазером
            shootTimer = 0f; // Сбрасываем таймер обратно
        }
    }

    void ShootLaser()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        Vector3 direction = transform.up;
        laser.transform.position += direction * shootingForce * Time.deltaTime; // Двигаем лазер вперед с постоянной скоростью
    }

}
