using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour

{
    public GameObject laserPrefab; // Укажите ваш префаб лазера в инспекторе
    public float shootingForce = 10f; // Сила, с которой лазер будет двигаться

    void Start()
    {
        // Начинаем автоматическую стрельбу каждые 0,5 секунды
        InvokeRepeating("ShootLaser", 0f, 0.5f);
    }

    void ShootLaser()
    {
        // Создаем новый объект лазера
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        Vector3 direction = transform.up; // Лазер будет двигаться в направлении, в котором находится игрок
        rb.AddForce(direction * shootingForce, ForceMode2D.Impulse);
    }
}