using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkinControl : MonoBehaviour
{
    public static SkinControl Instance; // Статическая переменная для доступа к экземпляру

    public int skinNum;
    public Button buyButton;
    public int price;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;

    public Sprite[] skins; // Массив спрайтов скинов

    private void Awake()
    {
        // Инициализируем Instance в Awake
        Instance = this;
    }

    private void Start()
    {
        // Проверяем, куплен ли скин с номером 0 в начале игры
        if (PlayerPrefs.GetInt($"skin{0}buy") == 0)
        {
            // Если не куплен, покупаем его
            PlayerPrefs.SetInt($"skin{0}buy", 1);
            PlayerPrefs.SetInt("EquippedSkinNumber", 0); // Устанавливаем скин с номером 0 как используемый
            PlayerPrefs.SetInt($"skin{0}equip", 1);
        }
    }

    private void UpdateButtonState()
    {
        // Получаем номер активного скина из PlayerPrefs
        int activeSkinNum = PlayerPrefs.GetInt("EquippedSkinNumber");

        // Проверяем состояние каждого скина
        if (skinNum == 0)
        {
            buyButton.image.sprite = SkinDataController.Instance.purchasedSkins.Contains(0)
                ? (activeSkinNum == 0 ? equipped : equip)
                : buySkin;
        }
        else if (skinNum == 1)
        {
            buyButton.image.sprite = SkinDataController.Instance.purchasedSkins.Contains(1)
                ? (activeSkinNum == 1 ? equipped : equip)
                : buySkin;
        }
    }

    // Функция для покупки скина
    public void BuySkin(int skinNumber)
    {
        if (Coins.coinCount >= price)
        {
            Coins.RemoveCoins(price);
            PlayerPrefs.SetInt($"skin{skinNumber}buy", 1);
            SkinDataController.Instance.purchasedSkins.Add(skinNumber);
            SkinDataController.Instance.SaveData();
            Debug.Log($"Скин {skinNumber} куплен!");
        }
        else
        {
            Debug.Log("Недостаточно монет!");
        }
    }

    // Функция для установки скина
    public void SetSkin(int skinNumber)
    {
        // Проверяем, куплен ли скин
        if (SkinDataController.Instance.purchasedSkins.Contains(skinNumber))
        {
            // Сохраняем номер текущего скина
            PlayerPrefs.SetInt("EquippedSkinNumber", skinNumber);
            SkinDataController.Instance.SaveData();

            // Вызываем функцию для обновления внешнего вида игрока
            // (Предположим, что у вас есть объект игрока с компонентом SpriteRenderer)
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                player.GetComponent<SpriteRenderer>().sprite = skins[skinNumber];
            }
        }
    }
}