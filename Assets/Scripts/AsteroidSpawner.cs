using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _asteroidPrefabs;
    [SerializeField] private float _minVelocity;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _spawnDelayInSeconds;

    private Camera _camera;
    private bool _isSpawning;

    private void Awake()
    {
        _camera = Camera.main;
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

        /*
         * Spawn point based on viewport
         *          0
         *  -----------------------
         *  |                     |
         *  | 1                   | 3 
         *  |                     |
         *  |                     |
         *  -----------------------
         *          2
         * **/

        Vector2 spawnPointInViewport = Vector2.zero;
        Vector2 direction = Vector2.zero;

        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0:
                //Top
                spawnPointInViewport.y = 1f;
                spawnPointInViewport.x = Random.value;

                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
            case 1:
                //Left
                spawnPointInViewport.x = 0f;
                spawnPointInViewport.y = Random.value;

                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 2:
                //Bottom
                spawnPointInViewport.y = 0f;
                spawnPointInViewport.x = Random.value;

                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                //Right
                spawnPointInViewport.x = 1f;
                spawnPointInViewport.y = Random.value;

                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
        }

        Vector3 spawnPointInWorld = _camera.ViewportToWorldPoint(spawnPointInViewport);
        spawnPointInWorld.z = 0f;

        GameObject asteroridInstance = Instantiate(
            _asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Count)],
            spawnPointInWorld,
            Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        Rigidbody asteroidRB = asteroridInstance.GetComponent<Rigidbody>();
        asteroidRB.velocity = direction.normalized * Random.Range(_minVelocity, _maxVelocity);

        yield return new WaitForSeconds(_spawnDelayInSeconds);

        _isSpawning = false;
    }
}
