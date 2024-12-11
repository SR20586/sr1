using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public int rows1 = 2;
    public int columns1 = 6;
    public float xSpacing = 1.5f;
    public float ySpacing = 1.5f;
    public Transform spawnPoint;
    public Transform spawnPoint2;

    private int totalEnemies;
    private int enemiesDestroyed;
    private int spawnThreshold = 7;

    void Start()
    {
        SpawnInitialEnemies();
    }

    void SpawnInitialEnemies()
    {
        totalEnemies = rows1 * columns1;
        enemiesDestroyed = 0;
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < columns1; j++)
            {
                Vector3 spawnPosition = spawnPoint.position + new Vector3(j * xSpacing, i * ySpacing, 0);
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
                Instantiate(enemyPrefab2, spawnPosition, Quaternion.identity, transform);
                Vector3 spawnPosition2 = spawnPoint2.position + new Vector3(j * xSpacing, i * ySpacing, 0);
                Instantiate(enemyPrefab3, spawnPosition2, Quaternion.identity, transform);
            }
        }
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        if (enemiesDestroyed >= spawnThreshold)
        {
            enemiesDestroyed = 0;
            StartCoroutine(SpawnSingleEnemy());
        }
    }

    IEnumerator SpawnSingleEnemy()
    {
        yield return new WaitForSeconds(4f); // 1•b‘Ò‹@
        Vector3 spawnPosition = spawnPoint.position + new Vector3(Random.Range(0, columns1) * xSpacing, Random.Range(0, rows1) * ySpacing, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        Instantiate(enemyPrefab2, spawnPosition, Quaternion.identity, transform);
        Vector3 spawnPosition2 = spawnPoint2.position + new Vector3(Random.Range(0, columns1) * xSpacing, Random.Range(0, rows1) * ySpacing, 0);
        Instantiate(enemyPrefab3, spawnPosition2, Quaternion.identity, transform);
    }
}