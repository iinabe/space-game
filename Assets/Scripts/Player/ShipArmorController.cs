using UnityEngine;

public class ShipArmorController : MonoBehaviour
{
    public ArmorBar armorBar;
    
    private int maxArmor = 100;
    private int _currentArmor;
    
    public SpriteRenderer outline; // Ссылка на объект обводки

    private void Start()
    {
        if (armorBar != null)
        {
            _currentArmor = 100;
            
            armorBar.SetMaxArmor(maxArmor);
            armorBar.SetArmor(_currentArmor);
        }
    }

    // Метод для скрытия обводки
    private void HideOutline()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    // Метод для отображения обводки
    private void ShowOutline()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    public int TryDamage(int damage)
    {
        if (_currentArmor > 0)
        {
            int armorDamage = Mathf.Min(damage, _currentArmor);
            _currentArmor -= armorDamage;
            damage -= armorDamage;

            // Обновляем полоску брони
            if (armorBar != null)
            {
                armorBar.SetArmor(_currentArmor);
            }

            if (_currentArmor <= 0)
            {
                HideOutline();
            }
        }

        return damage;


    }


}
