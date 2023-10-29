using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] float xRange = 2f;

    [SerializeField] float minSpawnRate = .1f;
    [SerializeField] float maxSpawnRate = 1.1f;

    void Start()
    {
        StartCoroutine(StartSpawnEnemy());
    }

    IEnumerator StartSpawnEnemy()
    {
        while(!GameManager.Instance.IsGameOver)
        {
            var enemy = Instantiate(enemyPrefab, transform.position,Quaternion.identity);
            Vector2 newPos = enemy.transform.position;
            newPos.x = Random.Range(-xRange, xRange + .001f);
            enemy.transform.position = newPos;

            yield return new WaitForSeconds(Random.Range(minSpawnRate,maxSpawnRate));
        }
    }

}
