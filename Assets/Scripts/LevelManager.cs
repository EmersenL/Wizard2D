using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int count = 0;

    // get info from other scripts
    public bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {
            if (count == 0)
            {
                // Debug.Log("Press 'R' to Restart");
                count++;
            }
            SceneManager.LoadScene("GameOver");
            //if (Input.GetKeyDown("r"))
            //{
            //    SceneManager.LoadScene("StartGame");
            //}
        }
    }
}
