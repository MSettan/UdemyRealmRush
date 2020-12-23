using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private float secondsBetweenSpawn = 2f;

    void Start()
    {
        EnemyMovement enemyPrefabCopy = enemyPrefab;
        StartCoroutine(SpawnEnemies(enemyPrefabCopy));
    }

    IEnumerator SpawnEnemies(EnemyMovement enemyPrefabCopy)
    {
        while (true)
        {
            Instantiate(enemyPrefabCopy, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
