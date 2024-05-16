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
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        bool isSkinBought = PlayerPrefs.GetInt($"skin{skinNum}buy") == 1;
        bool isSkinEquipped = PlayerPrefs.GetInt($"skin{skinNum}equip") == 1;

        buyButton.image.sprite = isSkinBought
            ? (isSkinEquipped ? equipped : equip)
            : buySkin;
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
                PlayerPrefs.SetInt("skinNum", skinNum);
                PlayerPrefs.SetInt("Coins", Coins.coinCount);
                PlayerPrefs.SetInt($"skin{skinNum}equip", 1);
            }
            else
            {
                Debug.Log("Not enough coins!");
            }
        }
        else
        {
            PlayerPrefs.SetInt($"skin{skinNum}equip", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);
        }

        UpdateButtonState();
    }
}
