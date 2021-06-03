using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] private int startingWave = 0;
    [SerializeField] bool looping = false;
    [SerializeField] float timeBetweenWavesSpawn = 1.5f;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (looping) 
        { 
            yield return StartCoroutine(SpawnAllWaves()); 
        }
    }

    private IEnumerator SpawnAllWaves()
    {


        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            yield return new WaitForSeconds(timeBetweenWavesSpawn);
        }
    }


    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {

        float timeBetweenEnemySpawn = waveConfig.TimeBetweenSpawns;
        timeBetweenEnemySpawn = Random.Range(0.4f, 0.5f);

        for (int enemyCount = 0; enemyCount < waveConfig.NumberOfEnemies; enemyCount++)
        {
            var newEnemy = Instantiate(
            waveConfig.EnemyPrefab,
            waveConfig.GetWaypoints()[0].position,
            Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().WaveConfig=waveConfig;
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }
        
    }

}
