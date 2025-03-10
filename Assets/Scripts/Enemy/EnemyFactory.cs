using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float cooldown = 20.0f;
    public int mobCap = 20;
    public float xRange;
    public float yRange;
    public float zRange;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
    }

    public IEnumerator SpawnEnemy()
    {
        int enemiesSpawned = 0;

        while (enemiesSpawned < mobCap)
        {
            Instantiate(enemyPrefab, new Vector3(-7.0f, 10.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-14.0f, 4.5f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-26.0f, 7.5f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-38.0f, -1.4f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-18.0f, 18.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-2.0f, 20.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-2.0f, 29.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-20.0f, 17.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(22.0f, 30.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(42.0f, 29.5f, 0.0f), Quaternion.identity);
            enemiesSpawned++;

            yield return new WaitForSeconds(cooldown);
        }
    }
}
