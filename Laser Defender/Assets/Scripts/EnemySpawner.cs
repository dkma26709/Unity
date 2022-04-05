using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveconfigs;
    WaveConfigSO currentWave;

    [SerializeField] float timeBetweenWaves = 0f;

    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    private IEnumerator SpawnEnemiesWaves()
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
    }
}
