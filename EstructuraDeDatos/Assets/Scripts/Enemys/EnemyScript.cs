using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Sprite EnemySprite;
    [Header("Enemy Attributes")] public float health;
    public float speed;

    [Header("Player")] public GameObject player;
    private float distance;

    private LevelManager LevelManager;

    private void Start()
    {
        LevelManager = FindObjectOfType<LevelManager>();
        EnemySprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        // Perseguir al Jugador
        distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance < 20)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    // Daño del Enemigo
    public void EnemyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            LevelManager.enemyCounter++;
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            this.GetComponent<Animator>().SetTrigger("isDead");

            if (this.GetComponentInChildren<RangedEnemy>())
            {
                this.GetComponentInChildren<RangedEnemy>().canShoot = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            LevelManager.enemyCounter++;
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            this.GetComponent<Animator>().SetTrigger("isDead");

            if (this.GetComponentInChildren<RangedEnemy>())
            {
                this.GetComponentInChildren<RangedEnemy>().canShoot = false;
            }
        }
    }
}