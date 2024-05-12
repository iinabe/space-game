using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public static int coinCount; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AddCoins(2); 
            Destroy(gameObject);
        }
    }

    public static void AddCoins(int amount)
    {
        coinCount += amount;
        PlayerPrefs.SetInt("Coins", coinCount);
    }

    public static void RemoveCoins(int amount)
    {
        coinCount -= amount;
        PlayerPrefs.SetInt("Coins", coinCount);
    }
}
