using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SkinSelect()
    {
        SceneManager.LoadScene("SkinSelection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
