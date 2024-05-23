using UnityEngine;

public class ShipArmorController : MonoBehaviour
{
    public ArmorBar armorBar;
    public SpriteRenderer outline; // Ссылка на объект обводки

    private int maxArmor = 100;
    private int _currentArmor;

    private void Start()
    {
        _currentArmor = maxArmor;
        if (armorBar != null)
        {
            armorBar.SetMaxArmor(maxArmor);
            armorBar.SetArmor(_currentArmor);
        }
        ShowOutline(); // Предполагаем, что обводка должна быть видна изначально
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

        return damage; // Возвращаем оставшийся урон
    }

    public void HealArmor(int healArmorAmount)
    {
        if (_currentArmor < maxArmor) // Проверка, нужно ли вообще лечить броню
        {
            _currentArmor += healArmorAmount;
            _currentArmor = Mathf.Min(_currentArmor, maxArmor);

            if (armorBar != null)
            {
                armorBar.SetArmor(_currentArmor);
            }

            Debug.Log("Броня увеличена на " + healArmorAmount + ", текущая броня: " + _currentArmor);
            ShowOutline(); // Показываем обводку при восстановлении брони
        }
        else
        {
            Debug.Log("Броня уже на максимуме.");
        }
    }
}
