using UnityEngine;
using System.Collections.Generic;

// ���������� ������ ��� ������
public class SkinDataController : MonoBehaviour
{
    public static SkinDataController Instance; // ������ �� ��� ����

    public List<int> purchasedSkins = new List<int>();
    public int currentSkinNumber;

    private void Awake()
    {
        // �������������
        Instance = this;

        if (!PlayerPrefs.HasKey("firstlaunch")) 
        {
            PlayerPrefs.SetInt("firstlaunch", 0);
            PlayerPrefs.SetInt("skin0buy", 0);
            PlayerPrefs.SetInt("EquippedSkinNumber", 0);
        }

        // ��������� ������ � ��������� ������
        LoadPurchasedSkins();

        // ��������� ����� �������� �����
        currentSkinNumber = PlayerPrefs.GetInt("EquippedSkinNumber", 0); // 0 - ���� �� ���������
        
    }

    private void LoadPurchasedSkins()
    {
        // ���������, ������� ������ ��������
        int skinCounts = 2; // �������� �� ����������� ���������� ������
        for (int i = 0; i < skinCounts; ++i)
        {
            if (PlayerPrefs.HasKey($"skin{i}buy"))
            {
                purchasedSkins.Add(i);
            }
        }
    }

    // ������� ��� ���������� ������
    public void SaveData()
    {
        // ��������� ���������� � ��������� ������
        for (int i = 0; i < purchasedSkins.Count; i++)
        {
            PlayerPrefs.SetInt($"skin{purchasedSkins[i]}buy", 1);
        }
        PlayerPrefs.Save();
    }

    public bool IsBought(int skinnum) 
    {
        return purchasedSkins.Contains(skinnum);
    }

    public void EquipSkin(int skinnum) 
    {
        PlayerPrefs.SetInt("EquippedSkinNumber", skinnum);
        currentSkinNumber = skinnum;
    }

    public void Buy(int skinnum) 
    {
        PlayerPrefs.SetInt($"skin{skinnum}buy", 0);
        purchasedSkins.Add(skinnum);
    }
}
