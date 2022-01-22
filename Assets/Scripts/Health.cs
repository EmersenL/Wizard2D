using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //import player
    public GameObject player;
    public LevelManager levelM;

    public Image healthBar;
    public float healthAmount = 100;

    private void Awake()
    {
        player = GameObject.Find("Player");
        levelM = GameObject.Find("GameManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(player);
            levelM.isDead = true;
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100;

    }
}
