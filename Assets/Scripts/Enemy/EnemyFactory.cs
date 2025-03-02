using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public float cooldown = 5.0f;
    public GameObject enemyPrefab;
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
        while (true)
        {
            float x = Random.Range(-xRange, xRange);
            float y = Random.Range(-yRange, yRange);
            float z = Random.Range(-zRange, zRange);

            Instantiate(enemyPrefab, new Vector3(x, y, z), Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }
}
