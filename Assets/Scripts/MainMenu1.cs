using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
{
    // ����� ��� �������� ������� �����
    public void PlayGame()
    {
        // ��������� �����, ��������� ���, ���������� � ��������� GameSettings
        SceneManager.LoadScene(GameSettings.SceneNames.MainScene);
    }
    public void ExitGame()
    {
        Debug.Log("���� ���������");
        Application.Quit();
    }
}
