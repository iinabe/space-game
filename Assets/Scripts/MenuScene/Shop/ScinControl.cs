using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkinControl : MonoBehaviour
{
    public static SkinControl Instance; // ����������� ���������� ��� ������� � ����������

    public int skinNum;
    public Button buyButton;
    public int price;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;

    public Sprite[] skins; // ������ �������� ������

    private void Awake()
    {
        // �������������� Instance � Awake
        Instance = this;
    }

    private void Start()
    {
        // ���������, ������ �� ���� � ������� 0 � ������ ����
        if (PlayerPrefs.GetInt($"skin{0}buy") == 0)
        {
            // ���� �� ������, �������� ���
            PlayerPrefs.SetInt($"skin{0}buy", 1);
            PlayerPrefs.SetInt("EquippedSkinNumber", 0); // ������������� ���� � ������� 0 ��� ������������
            PlayerPrefs.SetInt($"skin{0}equip", 1);
        }
    }

    private void UpdateButtonState()
    {
        // �������� ����� ��������� ����� �� PlayerPrefs
        int activeSkinNum = PlayerPrefs.GetInt("EquippedSkinNumber");

        // ��������� ��������� ������� �����
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

    // ������� ��� ������� �����
    public void BuySkin(int skinNumber)
    {
        if (Coins.coinCount >= price)
        {
            Coins.RemoveCoins(price);
            PlayerPrefs.SetInt($"skin{skinNumber}buy", 1);
            SkinDataController.Instance.purchasedSkins.Add(skinNumber);
            SkinDataController.Instance.SaveData();
            Debug.Log($"���� {skinNumber} ������!");
        }
        else
        {
            Debug.Log("������������ �����!");
        }
    }

    // ������� ��� ��������� �����
    public void SetSkin(int skinNumber)
    {
        // ���������, ������ �� ����
        if (SkinDataController.Instance.purchasedSkins.Contains(skinNumber))
        {
            // ��������� ����� �������� �����
            PlayerPrefs.SetInt("EquippedSkinNumber", skinNumber);
            SkinDataController.Instance.SaveData();

            // �������� ������� ��� ���������� �������� ���� ������
            // (�����������, ��� � ��� ���� ������ ������ � ����������� SpriteRenderer)
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                player.GetComponent<SpriteRenderer>().sprite = skins[skinNumber];
            }
        }
    }
}