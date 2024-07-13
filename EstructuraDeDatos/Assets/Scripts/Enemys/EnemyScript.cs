using System;
using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Attributes")]
    public float health;
    private float currentHealth;
    public float speed;
    public bool isAlive = true;
    public bool isRangedEnemy;
    private Animator animator;
    private CapsuleCollider2D capsuleCollider2D;

    [Header("Enemy Information")]
    public string enemyName; // Añadir nombre del enemigo
    public Sprite EnemySprite; // Añadir sprite del enemigo

    [Header("Player")]
    public GameObject player;
    private float distance;

    private RangedEnemy rangedEnemy;

    public event Action<GameObject> OnEnemyKilled;
    public event Action OnEnemyRevived;

    private void Start()
    {
        EnemySetup();
        if (EnemySprite == null)
        {
            EnemySprite = gameObject.GetComponent<SpriteRenderer>().sprite; // Obtener sprite si no está asignado
        }
    }

    void Update()
    {
        if (player)
        {
            // Perseguir al Jugador
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 20)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }

    private void EnemySetup()
    {
        isAlive = true;
        currentHealth = health;

        if (capsuleCollider2D == null)
        {
            capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        }

        capsuleCollider2D.enabled = true;
        capsuleCollider2D.isTrigger = false;

        if (animator == null)
        {
            animator = gameObject.GetComponent<Animator>();
        }

        if (isRangedEnemy)
        {
            if (rangedEnemy == null)
            {
                rangedEnemy = gameObject.GetComponent<RangedEnemy>();
            }

            rangedEnemy.isWeaponActive = true;
            rangedEnemy.canShoot = true;
            StartCoroutine(rangedEnemy.UpdateWeaponStatus(0f));
        }
    }

    // Daño del Enemigo
    public void EnemyDamage(float damage)
    {
        if (isAlive)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                isAlive = false;
                capsuleCollider2D.enabled = false;
                animator.SetTrigger("isDead");

                OnEnemyKilled?.Invoke(this.gameObject);

                if (isRangedEnemy && gameObject.activeInHierarchy)
                {
                    rangedEnemy.canShoot = false;
                    rangedEnemy.isWeaponActive = false;
                    StartCoroutine(rangedEnemy.UpdateWeaponStatus(0f));
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            capsuleCollider2D.enabled = false;
            animator.SetTrigger("isDead");
            isAlive = false;

            OnEnemyKilled?.Invoke(this.gameObject);

            if (isRangedEnemy)
            {
                rangedEnemy.canShoot = false;
                rangedEnemy.isWeaponActive = false;
                StartCoroutine(rangedEnemy.UpdateWeaponStatus(0f));
            }
        }
    }

    public void EnemyRevive()
    {
        if (!isAlive)
        {
            isAlive = true;
            currentHealth = health;
            animator.SetTrigger("isRevived");

            if (isRangedEnemy)
            {
                rangedEnemy.isWeaponActive = true;
                StartCoroutine(rangedEnemy.UpdateWeaponStatus(1f));
                StartCoroutine(RangedReset(1.5f));
            }

            OnEnemyRevived?.Invoke();
        }
    }

    private IEnumerator RangedReset(float delay)
    {
        yield return new WaitForSeconds(delay);

        capsuleCollider2D.enabled = true;
        rangedEnemy.canShoot = true;
    }

    private void OnEnable()
    {
        EnemySetup();
    }
}
