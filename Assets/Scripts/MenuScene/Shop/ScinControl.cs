using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class SkinControl : MonoBehaviour
{
    public event Action Onclicked;
    public int skinNum;
    public Button buyButton;
    public int price;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;
    private bool isbought;
    private bool isequipped;

    private void Start()
    {
        isbought = SkinDataController.Instance.IsBought(skinNum);
        isequipped = SkinDataController.Instance.currentSkinNumber == skinNum;
        UpdateButtonState();
    }

    public void UpdateButtonState()
    {
        if (isequipped)
        { 
            buyButton.image.sprite = equipped;
        }
        else
        {
            if (isbought) {
            buyButton.image.sprite = equip;
            }
            else
            {
                buyButton.image.sprite = buySkin;
            }
        }

    }

    public void OnButtonClick() 
    {
        if (isequipped) 
        {
            return;
        }
        else
        {
            if (isbought)
            {
                EquipSkin();
            }
            else 
            {
                TryBuySkin();
            }
        }
    }

    public void EquipSkin() 
    {
        SkinDataController.Instance.EquipSkin(skinNum);
        Onclicked?.Invoke();
    }

    public void TryBuySkin()
    {
        if (Coins.coinCount >= price) 
        {
            Coins.RemoveCoins(price);
            Onclicked?.Invoke();
        }
    }
}
