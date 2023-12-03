using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
