using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public Sprite[] skins; // Массив спрайтов скинов

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSkin(SkinDataController.Instance.currentSkinNumber);
    }

    public void SetSkin(int skinNumber)
    {
        if (skinNumber >= 0 && skinNumber < skins.Length)
        {
            spriteRenderer.sprite = skins[skinNumber];
            Debug.Log($"Скин {skinNumber} установлен на игрока.");
        }
        else
        {
            Debug.LogError($"Скин номер {skinNumber} находится вне диапазона массива skins.");
        }
    }
}
