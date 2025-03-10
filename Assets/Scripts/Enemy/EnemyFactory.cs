using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float cooldown = 5.0f;
    public int enemiesToSpawn = 48;
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

        while (enemiesSpawned < enemiesToSpawn)
        {
            float x = Random.Range(-xRange, xRange);
            float y = Random.Range(-yRange, yRange);
            float z = Random.Range(-zRange, zRange);

            //Instantiate(enemyPrefab, new Vector3(x, y, z), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-7.0f, 10.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-14.0f, 4.5f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-26.0f, 7.5f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-38.0f, -1.4f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-18.0f, 18.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-2.0f, 20.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-2.0f, 29.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(22.0f, 30.0f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(42.0f, 29.5f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(37.8f, -0.26f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(39.0f, 9.83f, 0.0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(9.55f, 4.77f, 0.0f), Quaternion.identity);
            enemiesSpawned += 12;

            yield return new WaitForSeconds(cooldown);
        }
    }
}
