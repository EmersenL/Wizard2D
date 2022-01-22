using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public Health healthScript;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GameObject.Find("GameManager").GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthScript.Healing(100);
            Destroy(gameObject);
        }
    }
}
