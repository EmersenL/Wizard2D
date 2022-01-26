using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject mNum;

    // public Enemy enemyClass;

    //private void Awake()
    //{
    //    enemyClass.GetComponent<Enemy>();
    //}

    // Start is called before the first frame update
    void Start()
    {
        // enemyClass.PingDead += DeathCount;

        StartCoroutine(spawnEnemy(enemy1Interval, enemy1Prefab));
        StartCoroutine(spawnEnemy(bigEnemy1Interval, bigEnemy1Prefab));

        // now enemyCount has the number of monsters spawned
        mNum.GetComponent<Text>().text = "Monsters Left: " + enemyCount;
    }

    private void Update()
    {
        mNum.GetComponent<Text>().text = "Monsters Left: " + enemyCount;
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        int enemyNum = (int)Mathf.Floor(count / interval);
        enemyCount += enemyNum;

        for (int i = 0; i < enemyNum; i++)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(UnityEngine.Random.Range(-5f, 5), UnityEngine.Random.Range(-6f, 6f), 0), Quaternion.identity);
            // StartCoroutine(spawnEnemy(interval, enemy));
        }
    }

    //void DeathCount(object sender, EventArgs e)
    //{
    //    enemyCount -= 1;
    //    mNum.GetComponent<Text>().text = "Monsters Left: " + enemyCount;
    //}
}
