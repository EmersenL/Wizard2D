using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1Prefab;
    [SerializeField]
    private GameObject bigEnemy1Prefab;

    [SerializeField]
    private float enemy1Interval = 3.5f;
    [SerializeField]
    private float bigEnemy1Interval = 10f;

    private float count = 30;
    public float enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemy1Interval, enemy1Prefab));
        StartCoroutine(spawnEnemy(bigEnemy1Interval, bigEnemy1Prefab));

        // now enemyCount has the number of monsters spawned
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        int enemyNum = (int)Mathf.Floor(count / interval);
        enemyCount += enemyNum;

        for (int i = 0; i < enemyNum; i++)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
            // StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
