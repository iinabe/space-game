using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkinControl : MonoBehaviour
{
    public static int CurrentSkinNumber { get; private set; } = 0; // ����� �������� �����

    public int skinNum;
    public Button buyButton;
    public int price;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;

    private void Start()
    {
        // ������������� ������� ���� ��� �������� �����
        SetSkin(PlayerPrefs.GetInt("EquippedSkinNumber", 0));
    }

    private void UpdateButtonState()
    {
        if (skinNum == 0 && CurrentSkinNumber == 0)
        {
            buyButton.image.sprite = equipped; // ���� ����� 0 ����� ������, ���� ������
            return;
        }

        if (SkinDataController.Instance.purchasedSkins.Contains(skinNum))
        {
            if (CurrentSkinNumber == skinNum)
            {
                buyButton.image.sprite = equipped; // ���� �����
            }
            else
            {
                buyButton.image.sprite = equip; // ���� ������, �� �� �����
            }
        }
        else
        {
            buyButton.image.sprite = buySkin; // ���� �� ������, ���������� ����
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
            Debug.Log($"���� {skinNumber} ������!");
            UpdateButtonState(); // ��������� ��������� ������ ����� �������
        }
        else
        {
            Debug.Log("������������ �����!");
        }
    }

    public void SetSkin(int skinNumber)
    {
        if (skinNumber == 0 || SkinDataController.Instance.purchasedSkins.Contains(skinNumber))
        {
            // ������� ���������� ����
            int previousSkinNumber = CurrentSkinNumber;
            if (previousSkinNumber != skinNumber)
            {
                PlayerPrefs.SetInt($"skin{previousSkinNumber}equip", 0);
            }

            // ��������� ����� �������� �����
            CurrentSkinNumber = skinNumber;
            PlayerPrefs.SetInt("EquippedSkinNumber", skinNumber);
            PlayerPrefs.SetInt($"skin{skinNumber}equip", 1);
            SkinDataController.Instance.SaveData();
            UpdateButtonState(); // ��������� ��������� ������ ����� ����� �����
        }
        else
        {
            Debug.LogError($"���� ����� {skinNumber} �� ������.");
        }
    }
}
