using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> wayPoints;

    int wayPointIndex = 0;
    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        waveConfig = enemySpawner.GetCurrentWave();
    }
    void Start()
    {
        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[0].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
