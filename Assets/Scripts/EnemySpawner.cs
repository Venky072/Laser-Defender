using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveConfigSo currentWave;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] List <WaveConfigSo> waveConfigs;
    [SerializeField] bool isLooping;
    void Start()
    {
        StartCoroutine (spawnEnemyWaves());
    }

    public WaveConfigSo GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator spawnEnemyWaves()
    {
        do{
            foreach (WaveConfigSo wave in waveConfigs)
            {
                currentWave = wave;
                for(int i = 0 ; i < currentWave.GetEnemyCount() ; i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWayPoint().position,
                                Quaternion.Euler(0,0,180),
                                transform);
                        yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }while(isLooping);
    }
}
