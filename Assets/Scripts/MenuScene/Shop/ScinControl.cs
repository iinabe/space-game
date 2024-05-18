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
        // ���������, ������ �� ���� � ������� 0 � ������ ����
        if (PlayerPrefs.GetInt($"skin{0}buy") == 0)
        {
            // ���� �� ������, �������� ���
            PlayerPrefs.SetInt($"skin{0}buy", 1);
            PlayerPrefs.SetInt("skinNum", 0); // ������������� ���� � ������� 0 ��� ������������
            PlayerPrefs.SetInt($"skin{0}equip", 1);
        }

        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        // �������� ����� ��������� ����� �� PlayerPrefs
        int activeSkinNum = PlayerPrefs.GetInt("skinNum");

        // ��������� ��������� ������� �����
        bool isSkin0Bought = PlayerPrefs.GetInt($"skin{0}buy") == 1;
        bool isSkin1Bought = PlayerPrefs.GetInt($"skin{1}buy") == 1;

        // ��������� ������ ������ ��� ������� �����
        if (skinNum == 0)
        {
            buyButton.image.sprite = isSkin0Bought
                ? (activeSkinNum == 0 ? equipped : equip)
                : buySkin;
        }
        else if (skinNum == 1)
        {
            // ���� ���� � ������� 1 ������, �� �� ������� (skinNum 0 �������), �� ���������� equip
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
                PlayerPrefs.SetInt("skinNum", skinNum); // ������������� ����� ���� ��� ��������
                PlayerPrefs.SetInt("Coins", Coins.coinCount);
                PlayerPrefs.SetInt($"skin{skinNum}equip", 1);

                // ���� ������ ����� ����, �� ��������� ����������
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
        else // ���� ���� ��� ������, ������ ����������� ���
        {
            // ��������� ������� �������� ����
            if (skinNum == 0) // ���������, ��� ������ ��� ����� 0
            {
                PlayerPrefs.SetInt($"skin{1}equip", 0); // ��������� ���� 1
                PlayerPrefs.SetInt("skinNum", 0); // ������������� ���� 0 ��� ��������
            }
            else // ������ ������ ��� ����� 1
            {
                PlayerPrefs.SetInt($"skin{0}equip", 0); // ��������� ���� 0
                PlayerPrefs.SetInt("skinNum", 1); // ������������� ���� 1 ��� ��������
            }
        }
        UpdateButtonState();
    }
}