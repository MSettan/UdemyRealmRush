using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private float secondsBetweenSpawn = 2f;
    [SerializeField] private Transform parentEnemy;
    [SerializeField] private Text enemyCountText;
    [SerializeField] private AudioClip enemySpawnSound; 
    
    private int enemyCount = 0;
    
    void Start()
    {
        EnemyMovement enemyPrefabCopy = enemyPrefab;
        StartCoroutine(SpawnEnemies(enemyPrefabCopy));
        enemyCountText.text = enemyCount.ToString();
    }

    IEnumerator SpawnEnemies(EnemyMovement enemyPrefabCopy)
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(enemySpawnSound);
            enemyCount++;
            enemyCountText.text = enemyCount.ToString();
            var newEnemy = Instantiate(enemyPrefabCopy, gameObject.transform.position, Quaternion.identity);
            newEnemy.transform.parent = parentEnemy;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
