using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreDisplay;
    public Text endScoreDisplay;
    public Text bestScoreDisplay;
    public GameObject gameOverScene;
    public GameObject pauseScreen;
    public bool isPaused = false;
    public BirdScript bird;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", 0);
        }
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame == true && bird.LiveState())
        {
            if (!isPaused) pauseGame();
            else resumeGame();
        }
    }
    public void pauseGame()
    {
        isPaused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;        
    }
    public void resumeGame()
    {
        isPaused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;        
    }

    [ContextMenu("Increase score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreDisplay.text = playerScore.ToString();
    }
    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void mainMenu()
    {
        resumeGame();
        SceneManager.LoadScene("TitleScene");
    }

    public void gameOver()
    {
        endScoreDisplay.text = playerScore.ToString();
        if (playerScore > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", playerScore);
        }
        bestScoreDisplay.text = PlayerPrefs.GetInt("bestScore").ToString();
        gameOverScene.SetActive(true);
    }
}
