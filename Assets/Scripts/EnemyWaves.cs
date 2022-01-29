using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyWaves : MonoBehaviour
{

    private static EnemyWaves instance;

    private int wave = 0;//starts from wave 0

    [SerializeField]
    private Wave[] waves = default;

    private Wave CurrentWave => waves[Mathf.Min(waves.Length - 1, wave)];

    [Serializable]
    public class Wave
    {
        [Min(0)]
        public int numEnemies;
        [Min(0)]
        public float spawnInterval;
        [Min(0)]
        public float enemySpeed;
    }

    [Min(0)]
    [SerializeField]
    private float betweenWavesDelay = default;

    [SerializeField]
    private GameObject enemyPrefab = default;

    [Min(0)]
    [SerializeField]
    private float spawnDistanceFrom0 = 5;

    private int enemiesDefeatedThisWave = 0;

    private void Awake()
    {
        instance = this;
        Enemy.OnEnemyDefeated += OnEnemyDefeated;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDefeated -= OnEnemyDefeated;
    }

    private void OnEnemyDefeated()
    {
        enemiesDefeatedThisWave++;
        if (enemiesDefeatedThisWave >= CurrentWave.numEnemies)
        {
            StartCoroutine(StartNewWave());
        }
    }

    private IEnumerator StartNewWave()
    {
        enemiesDefeatedThisWave = 0;
        wave++;
        Debug.Log("Wave complete! Entering wave " + wave);
        if (betweenWavesDelay > 0)
            yield return new WaitForSeconds(betweenWavesDelay);
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        Debug.Log("Spawning " + CurrentWave.numEnemies + " enemies.");
        for (int i = 0; i < CurrentWave.numEnemies; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, Random.insideUnitCircle.normalized * spawnDistanceFrom0, Quaternion.identity).GetComponent<Enemy>();
            enemy.Initialize(CurrentWave.enemySpeed);
            if (i < CurrentWave.numEnemies - 1)//skip last element
                yield return new WaitForSeconds(CurrentWave.spawnInterval);
        }
    }

}