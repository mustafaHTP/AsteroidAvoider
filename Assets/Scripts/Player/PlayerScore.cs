using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private float _scoreMultiplier = 1f;

    private float _score;
    public static string ScoreKey = "Score";

    public float Score { get => _score; }

    private void Update()
    {
        _score += _scoreMultiplier * Time.deltaTime;
        PlayerPrefs.SetFloat(ScoreKey, _score);
    }

    /// <summary>
    /// Instead of update score in every frame
    /// update only when object is disabled
    /// </summary>
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(ScoreKey, _score);
    }
}
