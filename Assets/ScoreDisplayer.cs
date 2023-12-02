using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private PlayerScore _playerScore;

    void Update()
    {
        if (_playerScore != null)
        {
            _scoreTMP.text = Mathf.RoundToInt(_playerScore.Score).ToString();
        }
    }
}
