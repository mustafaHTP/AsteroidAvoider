using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerDeathHandler _playerDeathHandler;

    public void Crash()
    {
        _playerDeathHandler.ProcessCrash();
        gameObject.SetActive(false);
    }
}
