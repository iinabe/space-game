using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public Sprite[] skins; // ������ �������� ������

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SkinDataController.Instance.GetCurrentSprite();
    }
}
