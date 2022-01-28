using UnityEngine;

public sealed class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Transform[] spawns;

    [SerializeField]
    private float timeBetweenSpawns = 3;

    [SerializeField]
    private float timer;

    void Start()
    {
        timer = timeBetweenSpawns;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = timeBetweenSpawns;

            var spawn = spawns[Random.Range(0, spawns.Length)];

			Instantiate(enemyPrefab, spawn);
        }
    }
}
