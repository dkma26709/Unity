using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveconfigs;

    Player player;
    WaveConfigSO currentWave;

    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool playing = true;

    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
        player = FindObjectOfType<Player>();
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    private IEnumerator SpawnEnemiesWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveconfigs)
            {
                currentWave = wave;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                    yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime()); 
                }

                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }
        } while (playing);
    }
}
