using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _asteroidSpawner;
    [SerializeField] private GameObject _scoreDisplay;
    [SerializeField] private GameObject _player;

    public void ProcessCrash()
    {
        _gameOverMenu.SetActive(true);
        _asteroidSpawner.SetActive(false);
        _scoreDisplay.SetActive(false);
    }

    public void RespawnPlayer()
    {
        _gameOverMenu.SetActive(false);
        _asteroidSpawner.SetActive(true);
        _scoreDisplay.SetActive(true);
        _player.SetActive(true);

        //respawn player middle of the screen
        Vector2 respawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        _player.transform.position = respawnPosition;

        if (_player.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
}
