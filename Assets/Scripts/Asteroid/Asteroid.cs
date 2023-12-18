using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private AsteroidPool _asteroidPool;

    public void Init(AsteroidPool asteroidPool)
    {
        _asteroidPool = asteroidPool;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.Crash();
        }
    }

    private void OnBecameInvisible()
    {
        _asteroidPool.Pool.Release(this);
    }
}
