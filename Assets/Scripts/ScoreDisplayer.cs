using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private PlayerScore _playerScore;

    void Update()
    {
        _scoreTMP.SetText($"{Mathf.RoundToInt(_playerScore.Score)}");
    }
}
