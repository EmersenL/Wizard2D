using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject textDisplay;
    int secondsLeft = 5;
    public bool takingAway = false;

    public EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("wut " + secondsLeft);
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
            // Debug.Log("seconds left: " + secondsLeft);
        }
        else if (secondsLeft <= 0)
        {
            enemySpawner.trip = false;
            Destroy(gameObject);
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
    }
}
