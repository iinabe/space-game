using UnityEngine;

public class ShipArmorController : MonoBehaviour
{
    public GameObject Ship; // Ссылка на объект обводки


    // Метод для скрытия обводки
    public void HideOutline()
    {
        if (Ship != null)
        {
            Ship.SetActive(false);
        }
    }

    // Метод для отображения обводки
    public void ShowOutline()
    {
        if (Ship != null)
        {
            Ship.SetActive(true);
        }
    }


}
