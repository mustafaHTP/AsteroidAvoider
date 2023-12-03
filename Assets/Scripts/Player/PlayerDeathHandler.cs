using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _asteroidSpawner;
    [SerializeField] private GameObject _scoreDisplay;
    [SerializeField] private GameObject _player;
    [Tooltip("When player is respawned, to avoid instant any other collision, " +
        "enable collider by a little delay")]
    [SerializeField] private float _enablingColliderDelay;

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

        //respawn player middle of the screen
        Vector2 respawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        _player.transform.position = respawnPosition;

        if (_player.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.velocity = Vector2.zero;
        }

        _player.SetActive(true);
        ProtectSpawn();

        Invoke(nameof(EnableCollider), _enablingColliderDelay);
    }

    /// <summary>
    /// When player is spawned, avoid any other instant collision 
    /// </summary>
    private void ProtectSpawn()
    {
        PlayRespawnAnimation();
        DisableCollider();
    }

    private void PlayRespawnAnimation()
    {
        if (_player.TryGetComponent(out Animator animator))
        {
            animator.SetBool("isRespawning", true);
        }
    }

    private void DisableCollider()
    {
        if (_player.TryGetComponent(out MeshCollider meshCollider))
        {
            meshCollider.enabled = false;
        }
    }

    private void EnableCollider()
    {
        _player.GetComponent<MeshCollider>().enabled = true;
        if (_player.TryGetComponent(out Animator animator))
        {
            animator.SetBool("isRespawning", false);
        }
    }
}
