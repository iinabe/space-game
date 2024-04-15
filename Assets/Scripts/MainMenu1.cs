using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
{
    // Метод для загрузки главной сцены
    public void PlayGame()
    {
        // Загружаем сцену, используя имя, хранящееся в структуре GameSettings
        SceneManager.LoadScene(GameSettings.SceneNames.MainScene);
    }
    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}
