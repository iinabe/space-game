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
            ShipArmorController shipArmorController = other.gameObject.GetComponent<ShipArmorController>();
            if (shipArmorController != null)
            {
                shipArmorController.HealArmor(healArmorAmount); 
            }
            Destroy(gameObject);
        }
    }
}
