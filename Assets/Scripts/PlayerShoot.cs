using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour

{
    public GameObject laserPrefab; // ������� ��� ������ ������ � ����������
    public float shootingForce = 10f; // ����, � ������� ����� ����� ���������

    void Start()
    {
        // �������� �������������� �������� ������ 0,5 �������
        InvokeRepeating("ShootLaser", 0f, 0.5f);
    }

    void ShootLaser()
    {
        // ������� ����� ������ ������
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        Vector3 direction = transform.up; // ����� ����� ��������� � �����������, � ������� ��������� �����
        rb.AddForce(direction * shootingForce, ForceMode2D.Impulse);
    }
}