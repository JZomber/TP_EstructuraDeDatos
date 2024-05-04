using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Attributes")] public float health;
    public float speed;

    [Header("Player")] public GameObject player;
    private float distance;

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
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            this.GetComponent<Animator>().SetTrigger("isDead");
            // Destroy(gameObject);
        }
    }
}