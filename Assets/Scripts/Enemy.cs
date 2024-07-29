using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed = 5f;            // Speed of the enemy
    public float rotationSpeed = 2f;    // Speed of rotation towards the player
    public float maxHP = 100;         // Maximum health of the enemy
    public float damagePerSecond = 10f; // Damage dealt per second by the flashlight
    public Animator animator;        // Reference to the enemy's animator component
    public AudioSource deathSound;   // Reference to the enemy's death sound

    private Transform player;           // Transform of player
    private float currentHP;          // Current health of the enemy
    private bool isIlluminated = false;
    private Coroutine damageCoroutine;

    public GameObject enemyPrefab;

    void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHP = maxHP;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;  // Disable gravity for flying behavior
        }

        Collider collider = GetComponent<Collider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<SphereCollider>();
        }

        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        // Rotate towards the player
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Move towards the player
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if enemy is destroyed
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            if (!isIlluminated)
            {
                isIlluminated = true;
                damageCoroutine = StartCoroutine(ApplyDamageOverTime());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            if (isIlluminated)
            {
                isIlluminated = false;
                StopCoroutine(damageCoroutine);
            }
        }
    }

    IEnumerator ApplyDamageOverTime()
    {
        while (isIlluminated)
        {
            TakeDamage(damagePerSecond * Time.deltaTime);
            yield return null;
        }
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
        // Play death animation
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Play death sound
        if (deathSound != null)
        {
            deathSound.Play();
        }

        // Wait for the animation and sound to finish before destroying the enemy
        float deathDuration = 0;
        if (animator != null)
        {
            deathDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        }
        if (deathSound != null)
        {
            deathDuration = Mathf.Max(deathDuration, deathSound.clip.length);
        }

        Destroy(gameObject, deathDuration);
    }

}