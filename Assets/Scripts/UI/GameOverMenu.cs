using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    private void Start()
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

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
