using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class AsteroidPool : MonoBehaviour
{
    [SerializeField] private List<Asteroid> _asteroidPrefabs;
    [SerializeField] private int _defaultCapacity = 5;
    [SerializeField] private int _maxSize = 10;

    private IObjectPool<Asteroid> _asteroidPool;

    public IObjectPool<Asteroid> Pool => _asteroidPool;

    private void Awake()
    {
        _asteroidPool = new ObjectPool<Asteroid>(
            OnCreate, 
            OnGet, 
            OnRelease, 
            OnDestroyAsteroid, 
            false, 
            _defaultCapacity, 
            _maxSize);
    }

    #region Pool Methods

    private Asteroid OnCreate()
    {
        return Instantiate(
            GetRandomAsteroidPrefab(), 
            transform.position, 
            Quaternion.identity, 
            transform);
    }
    
    private void OnGet(Asteroid asteroid)
    {
        asteroid.gameObject.SetActive(true);
    }

    private void OnRelease(Asteroid asteroid)
    {
        asteroid.transform.position = transform.position;
        asteroid.gameObject.SetActive(false);
    }

    private void OnDestroyAsteroid(Asteroid asteroid)
    {
        Destroy(asteroid.gameObject);
    }

    #endregion

    private Asteroid GetRandomAsteroidPrefab()
    {
        int randomIndex = Random.Range(0, _asteroidPrefabs.Count);
        return _asteroidPrefabs[randomIndex];
    }
}
