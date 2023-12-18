using System.Buffers.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _asteroidPrefabs;
    [SerializeField] private float _minVelocity;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _spawnDelayInSeconds;

    private Camera _camera;
    private AsteroidPool _asteroidPool;
    private bool _isSpawning;

    private void Awake()
    {
        _camera = Camera.main;
        _asteroidPool = GetComponent<AsteroidPool>();
    }

    private void OnEnable()
    {
        _isSpawning = false;
    }

    private void Update()
    {
        if (!_isSpawning)
        {
            StartCoroutine(SpawnAsteroid());
        }
    }

    private IEnumerator SpawnAsteroid()
    {
        _isSpawning = true;

        Border cameraBorder = _camera.GetBorder();

        int sideNumber = GetRandomSide();
        Vector2 spawnPointInViewport = DecideAsteroidSpawnPointInViewPort(sideNumber);
        Vector2 asteroidDirection = DecideAsteroidDirection(sideNumber);

        //Translate spawn point to world space
        Vector3 spawnPointInWorld = _camera.ViewportToWorldPoint(spawnPointInViewport);
        spawnPointInWorld.z = 0f;

        //Get asteroid from pool
        GameObject asteroridInstance = _asteroidPool.Pool.Get().gameObject;

        //Set pool for asteroid
        asteroridInstance.GetComponent<Asteroid>().Init(_asteroidPool);

        //Set spawn point 
        asteroridInstance.transform.position = spawnPointInWorld;

        //Set random rotation
        asteroridInstance.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        Rigidbody asteroidRB = asteroridInstance.GetComponent<Rigidbody>();
        asteroidRB.velocity = asteroidDirection.normalized * Random.Range(_minVelocity, _maxVelocity);

        yield return new WaitForSeconds(_spawnDelayInSeconds);

        _isSpawning = false;
    }
    
    private Vector2 DecideAsteroidDirection(int side)
    {
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                //Top
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
            case 1:
                //Left
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 2:
                //Bottom
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                //Right
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
        }

        return direction;
    }

    private Vector2 DecideAsteroidSpawnPointInViewPort(int side)
    {
        Vector2 spawnPointInViewport = Vector2.zero;

        switch (side)
        {
            case 0:
                //Top
                spawnPointInViewport.y = 1f;
                spawnPointInViewport.x = Random.value;

                break;
            case 1:
                //Left
                spawnPointInViewport.x = 0f;
                spawnPointInViewport.y = Random.value;

                break;
            case 2:
                //Bottom
                spawnPointInViewport.y = 0f;
                spawnPointInViewport.x = Random.value;

                break;
            case 3:
                //Right
                spawnPointInViewport.x = 1f;
                spawnPointInViewport.y = Random.value;

                break;
        }

        return spawnPointInViewport;
    }

    /// <summary>
    ///
    /// * Spawn point based on viewport
    /// *          0
    /// *  -----------------------
    /// *  |                     |
    /// *  | 1                   | 3 
    /// *  |                     |
    /// *  |                     |
    /// *  -----------------------
    /// *          2
    /// *
    /// </summary>
    /// <returns> side number that asteroid will be spawned</returns>
    private int GetRandomSide()
    {
        return Random.Range(0, 4);
    }
}
