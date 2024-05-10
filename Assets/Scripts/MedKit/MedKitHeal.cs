using UnityEngine;
using UnityEngine.SceneManagement;

public class MedKitHeal : MonoBehaviour
{
    public int healAmount; // Количество здоровья, которое восстанавливает аптечка

    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("MedKit collided with kit!");
            HpController hpController = other.gameObject.GetComponent<HpController>();
            if (hpController != null)
            {
                hpController.Heal(healAmount); // Вызов метода для восстановления здоровья
            }
            Destroy(gameObject);
        }
    }
}
