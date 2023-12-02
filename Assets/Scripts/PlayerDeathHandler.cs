using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _asteroidSpawner;
    [SerializeField] private GameObject _scoreDisplay;

    public void ProcessCrash()
    {
        gameObject.SetActive(false);
        _gameOverMenu.SetActive(true);
        _asteroidSpawner.SetActive(false);
        _scoreDisplay.SetActive(false);
    }
}
