using UnityEngine;
using UnityEngine.SceneManagement;

public class MedKitHeal : MonoBehaviour
{
    public int healAmount; // ���������� ��������, ������� ��������������� �������

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Bullet collided with kit!");
            HpController hpController = other.gameObject.GetComponent<HpController>();
            if (hpController != null)
            {
                hpController.Heal(healAmount); // ����� ������ ��� �������������� ��������
            }
            Destroy(gameObject);
        }
    }
}
