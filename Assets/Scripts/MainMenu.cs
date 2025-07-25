using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        SceneManager.LoadScene("level 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //public void Restart()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
}
