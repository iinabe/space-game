using UnityEngine;
using System.Collections;

public class TimeDestroyer : MonoBehaviour
{

    //���������� ��� ������������ ���������� � �����
    public float timeToDestroy;

    //���������� ���� ��� ��� ������ �������
    void Start()
    {
        //��������� ������ ����� �������� �����
        Destroy(gameObject, timeToDestroy);
    }
}