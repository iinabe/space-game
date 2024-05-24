using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public Sprite[] skins; // Массив спрайтов скинов

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (spriteRenderer != null && SkinDataController.Instance != null)
        {
            spriteRenderer.sprite = SkinDataController.Instance.GetCurrentSprite();
        }
    }
}
