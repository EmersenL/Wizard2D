using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Health healthScript;
    public float moveSpeed = 5f;
    public float damage = 10;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float healthAmount = 100;

    public Player playerScript;

    [SerializeField]
    public GameObject hpotion;
    private float dropChance = .10f;
    public GameObject hp;

    //public event EventHandler OnPlayerDamaged;

    [SerializeField]
    private EnemyData data;

    // public event EventHandler PingDead;

    // Start is called before the first frame update

    public EnemySpawner spawner;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        healthScript = GameObject.Find("GameManager").GetComponent<Health>();
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }

        if (healthAmount <= 0)
        {
            // PingDead?.Invoke(this, EventArgs.Empty);
            spawner.enemyCount--;
            Loot();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            MoveCharacter(movement);
        }
    }

    void SetEnemyValues()
    {
        moveSpeed = data.speed;
        healthAmount = data.hp;
        damage = data.damage;
        dropChance = data.dropChance;
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        // healthBar.fillAmount = healthAmount / 100;
    }
    private void Loot()
    {
        if (UnityEngine.Random.value <= dropChance)
        {
            hp = Instantiate(hpotion, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerDamage")
        {
            TakeDamage(50);
        }
        else if (collision.gameObject.tag == "Player")
        {
            healthScript.TakeDamage(damage);


            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            Vector2 direction = collision.transform.position - transform.position;

            StartCoroutine(WaitALittle(direction, rb));

            // Debug.Log(playerScript.stopMoving);

            //OnPlayerDamaged?.Invoke(this, EventArgs.Empty);
            //playerScript.stopMoving = true;
            //for (int i = 0; i < 100; i++)
            //{
            //player.GetComponent<Rigidbody2D>().AddForce(movement * 50);
            //}
        }
    }

    IEnumerator WaitALittle(Vector2 direction, Rigidbody2D rb)
    {
        playerScript.stopMoving = true;
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.0001f);
            rb.AddForce(direction.normalized * 1.5f, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.2f);
        playerScript.stopMoving = false;
        // Debug.Log(playerScript.stopMoving);
    }
}
