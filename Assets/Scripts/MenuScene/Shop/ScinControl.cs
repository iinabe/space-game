using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkinControl : MonoBehaviour
{
    public static int CurrentSkinNumber { get; private set; } = 0; // Номер текущего скина

    public int skinNum;
    public Button buyButton;
    public int price;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;

    private void Start()
    {
        // Устанавливаем текущий скин при загрузке сцены
        SetSkin(PlayerPrefs.GetInt("EquippedSkinNumber", 0));
    }

    private void UpdateButtonState()
    {
        if (skinNum == 0 && CurrentSkinNumber == 0)
        {
            buyButton.image.sprite = equipped; // Скин номер 0 надет всегда, если куплен
            return;
        }

        if (SkinDataController.Instance.purchasedSkins.Contains(skinNum))
        {
            if (CurrentSkinNumber == skinNum)
            {
                buyButton.image.sprite = equipped; // Скин надет
            }
            else
            {
                buyButton.image.sprite = equip; // Скин куплен, но не надет
            }
        }
        else
        {
            buyButton.image.sprite = buySkin; // Скин не куплен, показываем цену
        }
    }

    public void BuySkin(int skinNumber)
    {
        if (Coins.coinCount >= price)
        {
            Coins.RemoveCoins(price);
            PlayerPrefs.SetInt($"skin{skinNumber}buy", 1);
            SkinDataController.Instance.purchasedSkins.Add(skinNumber);
            SkinDataController.Instance.SaveData();
            Debug.Log($"Скин {skinNumber} куплен!");
            UpdateButtonState(); // Обновляем состояние кнопки после покупки
        }
        else
        {
            Debug.Log("Недостаточно монет!");
        }
    }

    public void SetSkin(int skinNumber)
    {
        if (skinNumber == 0 || SkinDataController.Instance.purchasedSkins.Contains(skinNumber))
        {
            // Снимаем предыдущий скин
            int previousSkinNumber = CurrentSkinNumber;
            if (previousSkinNumber != skinNumber)
            {
                PlayerPrefs.SetInt($"skin{previousSkinNumber}equip", 0);
            }

            // Сохраняем номер текущего скина
            CurrentSkinNumber = skinNumber;
            PlayerPrefs.SetInt("EquippedSkinNumber", skinNumber);
            PlayerPrefs.SetInt($"skin{skinNumber}equip", 1);
            SkinDataController.Instance.SaveData();
            UpdateButtonState(); // Обновляем состояние кнопки после смены скина
        }
        else
        {
            Debug.LogError($"Скин номер {skinNumber} не куплен.");
        }
    }
}
