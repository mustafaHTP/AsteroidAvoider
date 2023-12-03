using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.Crash();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
