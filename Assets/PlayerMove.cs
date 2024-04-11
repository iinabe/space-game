using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    //���������� ��� ������� �����
    Vector3 clickPos;
    //���������� ��� ������� ��������
    Vector3 move;
    //���������� ��� �������� ��������
    public float speed = 1;
    //���������� ��� ������ �� Rigidbody2D
    Rigidbody2D rb;

    //���������� ���� ��� ��� ������ �������
    void Start()
    {
        //������ ������ �� ��������� Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //���-�� ������� ������� �� ����� � �� ������� � ����� (0,0,0)
        clickPos = transform.position;
    }

    //����������� ������ ����� ����
    void Update()
    {
        //��������, ������-�� ����� ������ ����
        if (Input.GetMouseButton(0))
        {
            //���������������� ���������� ������� � ���������� �������� ����
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //��������� ����� ������ ��������
        move = clickPos - transform.position;
    }

    //����������� ����� ������������ ������� (0.02 �� ���������). ����������� ��� ���������� ������
    void FixedUpdate()
    {
        //�������� ������ ��������
        //z ��������� 0, ���-�� ������� �� �������� �� z-���
        rb.velocity = new Vector2(move.x, move.y) * speed;
    }
}