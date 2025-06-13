using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSo waveConfigSo;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake() 
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();    
    }
    void Start()
    {
        waveConfigSo = enemySpawner.GetCurrentWave();
        waypoints = waveConfigSo.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }
    void Update()
    {
        followPath();
    }
    void followPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfigSo.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
                if(transform.position == targetPosition)
                {
                    waypointIndex++;
                }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
