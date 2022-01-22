using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ScreenBounds screenBounds;

    private void Awake()
    {
        screenBounds = GameObject.Find("ScreenBounds").GetComponent<ScreenBounds>();
    }

    private void FixedUpdate()
    {
        if (screenBounds.AmIOutOfBounds(transform.position))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
