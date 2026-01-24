using UnityEngine;
using System.Collections;

public class EnemySpanwner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenSpawns = 5f;
    void Start()
    {
      StartCoroutine(SpanwEnemy());
    }
    private IEnumerator SpanwEnemy()
    {
        Debug.Log("Spawning Enemies");
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
           GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        }
    }
  
}
