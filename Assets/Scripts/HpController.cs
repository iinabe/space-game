using UnityEngine;

public class HpController : MonoBehaviour
{
    public enum ObjectType { Player, Asteroid, Turret }

    public ObjectType objectType;

    private int hp;

    void Start()
    {
        switch (objectType)
        {
            case ObjectType.Player:
                hp = 100;
                break;
            case ObjectType.Asteroid:
                hp = 3;
                break;
            case ObjectType.Turret:
                hp = 3;
                break;
            default:
                hp = 100;
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
            Destroy(gameObject);
        }
    }
}
