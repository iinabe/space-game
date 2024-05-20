using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public Sprite[] skins; // ������ �������� ������

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSkin(SkinControl.CurrentSkinNumber);
    }

    public void SetSkin(int skinNumber)
    {
        if (skinNumber >= 0 && skinNumber < skins.Length)
        {
            spriteRenderer.sprite = skins[skinNumber];
            Debug.Log($"���� {skinNumber} ���������� �� ������.");
        }
        else
        {
            Debug.LogError($"���� ����� {skinNumber} ��������� ��� ��������� ������� skins.");
        }
    }
}
