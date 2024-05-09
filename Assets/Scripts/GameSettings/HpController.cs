using UnityEngine;
using System.Collections;

public class HpController : MonoBehaviour
{
    public enum ObjectType { Player, Asteroid, Turret }

    public ObjectType objectType;

    private int hp;
    private int maxHp = 100; // ћаксимальное значение здоровь€

    public GameObject Explosion;

    void Start()
    {
        switch (objectType)
        {
            case ObjectType.Player:
                hp = maxHp;
                break;
            case ObjectType.Asteroid:
                hp = 3;
                break;
            case ObjectType.Turret:
                hp = 3;
                break;
            default:
                hp = maxHp;
                break;
        }
    }

    public void MakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            if (objectType == ObjectType.Turret)
            {
                GetComponent<turretScript>().HpLost();
            }
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        hp += healAmount;
        Debug.Log("Health increased by " + healAmount + ", current health is " + hp);
        hp = Mathf.Min(hp, maxHp); // ќграничиваем значение здоровь€ максимальным значением
    }
}
