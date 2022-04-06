using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "Default Config")]
public class WaveConfigSO : ScriptableObject
{
  [SerializeField] Transform pathPrefab;
  [SerializeField] float moveSpeed = 5f;

  [Header("Spawn Time")]
  [SerializeField] float timeBetweenEnemySpawns = 1f;
  [SerializeField] float spawnTimeVariance = 0f;
  [SerializeField] float minimumSpawnTime = 0.2f;

  [SerializeField] List<GameObject> enemyPrefabs;

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

}
