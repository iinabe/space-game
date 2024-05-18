using UnityEngine;
using UnityEngine.UI;

public class SkinControl : MonoBehaviour
{
    public int skinNum;
    public Button buyButton;
    public int price;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;

    private void Start()
    {
        // Проверяем, куплен ли скин с номером 0 в начале игры
        if (PlayerPrefs.GetInt($"skin{0}buy") == 0)
        {
            // Если не куплен, покупаем его
            PlayerPrefs.SetInt($"skin{0}buy", 1);
            PlayerPrefs.SetInt("skinNum", 0); // Устанавливаем скин с номером 0 как используемый
            PlayerPrefs.SetInt($"skin{0}equip", 1);
        }

        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        // Получаем номер активного скина из PlayerPrefs
        int activeSkinNum = PlayerPrefs.GetInt("skinNum");

        // Проверяем состояние каждого скина
        bool isSkin0Bought = PlayerPrefs.GetInt($"skin{0}buy") == 1;
        bool isSkin1Bought = PlayerPrefs.GetInt($"skin{1}buy") == 1;

        // Обновляем спрайт кнопки для каждого скина
        if (skinNum == 0)
        {
            buyButton.image.sprite = isSkin0Bought
                ? (activeSkinNum == 0 ? equipped : equip)
                : buySkin;
        }
        else if (skinNum == 1)
        {
            // Если скин с номером 1 куплен, но не активен (skinNum 0 активен), то показываем equip
            buyButton.image.sprite = isSkin1Bought
                ? (activeSkinNum == 1 ? equipped : equip)
                : buySkin;
        }
    }

    public void Buy()
    {
        bool isSkinBought = PlayerPrefs.GetInt($"skin{skinNum}buy") == 1;

        if (!isSkinBought)
        {
            if (Coins.coinCount >= price)
            {
                Coins.RemoveCoins(price);
                PlayerPrefs.SetInt($"skin{skinNum}buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum); // Устанавливаем новый скин как активный
                PlayerPrefs.SetInt("Coins", Coins.coinCount);
                PlayerPrefs.SetInt($"skin{skinNum}equip", 1);

                // Если куплен новый скин, то отключаем предыдущий
                if (skinNum == 0)
                {
                    PlayerPrefs.SetInt($"skin{1}equip", 0);
                }
                else
                {
                    PlayerPrefs.SetInt($"skin{0}equip", 0);
                }
            }
            else
            {
                Debug.Log("Not enough coins!");
            }
        }
        else // Если скин уже куплен, просто переключаем его
        {
            // Выключаем текущий активный скин
            if (skinNum == 0) // Проверяем, что кнопка для скина 0
            {
                PlayerPrefs.SetInt($"skin{1}equip", 0); // Отключаем скин 1
                PlayerPrefs.SetInt("skinNum", 0); // Устанавливаем скин 0 как активный
            }
            else // Значит кнопка для скина 1
            {
                PlayerPrefs.SetInt($"skin{0}equip", 0); // Отключаем скин 0
                PlayerPrefs.SetInt("skinNum", 1); // Устанавливаем скин 1 как активный
            }
        }
        UpdateButtonState();
    }
}