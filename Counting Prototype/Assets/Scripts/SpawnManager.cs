using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int maxSpawn;
    [SerializeField] private float spawnPositionY;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float maxSpawnPositionX;

    private float _elapsedTime = 0.0f;
    private float _spawnTimer = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if (_elapsedTime >= _spawnTimer)
        {
            for (int i = 0; i < Random.Range(1, maxSpawn); i++)
            {
                Instantiate(coinPrefab, 
                    new Vector3(Random.Range(-maxSpawnPositionX, maxSpawnPositionX), spawnPositionY), 
                    new Quaternion());
            }

            _elapsedTime = 0.0f;
        }

        _elapsedTime += Time.deltaTime;
    }
}
