using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorKitHeal : MonoBehaviour
{
    public int healArmorAmount;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HpController hpController = other.gameObject.GetComponent<HpController>();
            if (hpController != null)
            {
                hpController.HealArmor(healArmorAmount); 
            }
            Destroy(gameObject);
        }
    }
}
