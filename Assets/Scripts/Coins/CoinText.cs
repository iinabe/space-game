using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public Text coinText; 

    void Start()
    {
        coinText = GetComponent<Text>(); 
        Coins.coinCount = PlayerPrefs.GetInt("Coins", Coins.coinCount);
    }

    void Update()
    {
        coinText.text = Coins.coinCount.ToString();
    }
}
