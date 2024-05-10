using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text CoinTexts;
    public static int Coin;
    void Start()
    {
        CoinTexts = GetComponent<Text>();
        Coin = PlayerPrefs.GetInt("Coins", Coin);
    }

    void Update()
    {
        CoinTexts.text = Coin.ToString();
    }
}
