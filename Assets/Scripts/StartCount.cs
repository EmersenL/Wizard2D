using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCount : MonoBehaviour
{
    private bool trip = false;

    [SerializeField]
    public EnemySpawner enemySpawner;
    [SerializeField]
    public GameObject countDownTimerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawner.enemyCount <= 0 && trip == false)
        {
            Debug.Log("we're IN!!!");
            GameObject newRoundCountdown = Instantiate(countDownTimerPrefab, new Vector3(-575.3f, -261.35f, 0), Quaternion.identity);
            trip = true;

            newRoundCountdown.transform.SetParent(this.transform, false);
            newRoundCountdown.SetActive(true);
            Debug.Log(newRoundCountdown);
        }
    }
}
