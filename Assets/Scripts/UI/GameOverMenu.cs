using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    [SerializeField] private AdManager _adManager;

    private void OnEnable()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        float score = PlayerPrefs.GetFloat(PlayerScore.ScoreKey, 0f);
        _scoreTMP.text = Mathf.RoundToInt(score).ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Scene_Game");
    }

    public void ContinueGame()
    {
        _adManager.ShowAd();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
