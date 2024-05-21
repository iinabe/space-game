using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Text gameOverText;
    public Button replayButton;
    public Button menuButton;
    public Text coinText; 

    void Start()
    {
        gameOverText.text = "GameOver";

        replayButton.onClick.AddListener(LoadReplayScene);
        menuButton.onClick.AddListener(LoadMenuScene);

        coinText.text = "Coins: " + Coins.coinCount; 
    }

    void LoadReplayScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}