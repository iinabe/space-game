using UnityEngine;
using UnityEngine.UI;
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

        // ��������� ������ � ��������� ������
        LoadPurchasedSkins();

        // ��������� ����� �������� �����
        currentSkinNumber = PlayerPrefs.GetInt("EquippedSkinNumber", 0); // 0 - ���� �� ���������

        // ������������� ���� �� ���������
        SkinControl.Instance.SetSkin(currentSkinNumber);
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
    }
}