using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// Контроллер данных для скинов
public class SkinDataController : MonoBehaviour
{
    public static SkinDataController Instance; // Ссылка на сам себя

    public List<int> purchasedSkins = new List<int>();
    public int currentSkinNumber;

    private void Awake()
    {
        // Инициализация
        Instance = this;

        // Загружаем данные о купленных скинах
        LoadPurchasedSkins();

        // Загружаем номер текущего скина
        currentSkinNumber = PlayerPrefs.GetInt("EquippedSkinNumber", 0); // 0 - скин по умолчанию

        // Устанавливаем скин по умолчанию
        SkinControl.Instance.SetSkin(currentSkinNumber);
    }

    private void LoadPurchasedSkins()
    {
        // Проверяем, сколько скинов доступно
        int skinCounts = 2; // Замените на фактическое количество скинов
        for (int i = 0; i < skinCounts; ++i)
        {
            if (PlayerPrefs.HasKey($"skin{i}buy"))
            {
                purchasedSkins.Add(i);
            }
        }
    }

    // Функция для сохранения данных
    public void SaveData()
    {
        // Сохраняем информацию о купленных скинах
        for (int i = 0; i < purchasedSkins.Count; i++)
        {
            PlayerPrefs.SetInt($"skin{purchasedSkins[i]}buy", 1);
        }
    }
}