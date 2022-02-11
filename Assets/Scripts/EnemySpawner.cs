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

    public StartCount startCount;

    private float count = 5;
    public float enemyCount = 0;

    public GameObject mNum;

    private float round = 1;

    public GameObject roundNum;
    public bool trip = true;

    public GameObject camera1;
    // private bool timerTrip = false;

    //[SerializeField]
    //public GameObject countDownTimerPrefab;

    //private bool trip = false;

    // public Enemy enemyClass;

    //private void Awake()
    //{
    //    enemyClass.GetComponent<Enemy>();
    //}

    // Start is called before the first frame update
    void Start()
    {
        camera1 = GameObject.Find("Main Camera");
        startCount = GameObject.Find("Canvas").GetComponent<StartCount>();

        // enemyClass.PingDead += DeathCount;
        roundNum = GameObject.Find("Round");

        StartCoroutine(spawnEnemy(enemy1Interval, enemy1Prefab));
        StartCoroutine(spawnEnemy(bigEnemy1Interval, bigEnemy1Prefab));

        // now enemyCount has the number of monsters spawned
        mNum.GetComponent<Text>().text = "Monsters Left: " + enemyCount;

        // display round #
        roundNum.GetComponent<Text>().text = "Round " + round;

        //increase round #
        round++;
    }

    private void Update()
    {
        if (trip == false)
        {
            StartCoroutine(spawnEnemy(enemy1Interval, enemy1Prefab));
            StartCoroutine(spawnEnemy(bigEnemy1Interval, bigEnemy1Prefab));

            // now enemyCount has the number of monsters spawned
            mNum.GetComponent<Text>().text = "Monsters Left: " + enemyCount;

            // display round #
            roundNum.GetComponent<Text>().text = "Round " + round;

            //increase round #
            round++;
            startCount.trip = false;
            trip = true;

            // increase difficulty
            IncreaseDifficulty(ref enemy1Interval, ref bigEnemy1Interval, ref count);
            //Debug.Log("en1 int: " + enemy1Interval + "\n" + "bigen1 int: " + bigEnemy1Interval + "\n");
            //Debug.Log("count: " + count + "\n");
        }
        mNum.GetComponent<Text>().text = "Monsters Left: " + enemyCount;
        //if (enemyCount == 0 && timerTrip == false)
        //{
        //    startCount.trip = false;
        //    timerTrip = true;
        //}
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        // makes it so that different types of enemies with different intervals finish spawning at the same time
        int enemyNum = (int)Mathf.Floor(count / interval);
        enemyCount += enemyNum;

        for (int i = 0; i < enemyNum; i++)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(GenerateSpawnLocation().x, GenerateSpawnLocation().y), Quaternion.identity);
            // StartCoroutine(spawnEnemy(interval, enemy));
        }
    }

    Vector2 GenerateSpawnLocation()
    {
        int radius = 10;
        Vector2 spawnPos = UnityEngine.Random.insideUnitCircle.normalized * radius;
        return spawnPos;
    }

    //Vector3 SpawnPointGenerator()
    //{
    //    camera1.
    //}

    //void DeathCount(object sender, EventArgs e)
    //{
    //    enemyCount -= 1;
    //    mNum.GetComponent<Text>().text = "Monsters Left: " + enemyCount;
    //}

    void IncreaseDifficulty(ref float enemy1Interval, ref float bigEnemy1Interval, ref float count)
    {
        count += 0.8f * count;
        enemy1Interval -= 0.2f * enemy1Interval;
        bigEnemy1Interval -= 0.2f * bigEnemy1Interval;
    }
}
