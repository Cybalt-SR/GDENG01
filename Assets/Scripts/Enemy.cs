using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed = 5f;            // Speed of the enemy
    public float rotationSpeed = 2f;    // Speed of rotation towards the player
    public float maxHP = 100;         // Maximum health of the enemy
    public float damagePerSecond = 10f; // Damage dealt per second by the flashlight
    public AudioSource deathSound;   // Reference to the enemy's death sound
    public AudioClip deathclip;
    float kill_dist = 1;

    private Transform player;           // Transform of player
    [SerializeField] private float currentHP;          // Current health of the enemy
    private bool isIlluminated = false;
    private Coroutine damageCoroutine;

    public GameObject enemyPrefab;
    Rigidbody rb;

    void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    void Start()
    {
        player = Player.Instance.transform;
        currentHP = maxHP;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Rotate towards the player
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        // Move towards the player
        rb.velocity += (transform.forward * speed * Time.deltaTime);

        // Check if enemy is destroyed
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }

        if(direction.sqrMagnitude <= kill_dist * kill_dist)
        {
            Killzone.Instance.Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            isIlluminated = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            isIlluminated = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Flashlight"))
            TakeDamage(damagePerSecond * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        deathSound.PlayOneShot(deathclip);
        Destroy(gameObject);
    }

}