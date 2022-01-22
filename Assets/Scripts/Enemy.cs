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

    [SerializeField]
    public GameObject hpotion;
    private float dropChance = .10f;
    public GameObject hp;

    [SerializeField]
    private EnemyData data;

    // Start is called before the first frame update
    void Start()
    {
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
        if (Random.value <= dropChance)
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
        }
    }
}
