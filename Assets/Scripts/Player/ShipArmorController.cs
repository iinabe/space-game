using UnityEngine;

public class ShipArmorController : MonoBehaviour
{
    public GameObject Ship; // ������ �� ������ �������


    // ����� ��� ������� �������
    public void HideOutline()
    {
        if (Ship != null)
        {
            Ship.SetActive(false);
        }
    }

    // ����� ��� ����������� �������
    public void ShowOutline()
    {
        if (Ship != null)
        {
            Ship.SetActive(true);
        }
    }


}
