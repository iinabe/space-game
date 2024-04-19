using UnityEngine;
using System.Collections;

public class HpController : MonoBehaviour {
    public int hp;

    public void MakeDamage(int damage)
    {
        hp -= damage;
       
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}