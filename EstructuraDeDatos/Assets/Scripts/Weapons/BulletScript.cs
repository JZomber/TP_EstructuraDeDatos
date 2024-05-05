using System;
using PowerUps;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Weapons
{
    public class BulletScript : MonoBehaviour
    {
        public float speed;
        private Rigidbody2D rb;

        public bool targetEnemy = true;
    
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * speed;
            Destroy(gameObject, 3);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (targetEnemy && collision.CompareTag("Enemy"))
            {
                EnemyScript enemy = collision.GetComponent<EnemyScript>();

                if (enemy != null)
                {
                    enemy.EnemyDamage(20);
                    Destroy(gameObject);
                }
            }

            if (!targetEnemy && collision.CompareTag("Shield"))
            {
                var shield = collision.gameObject.GetComponent<ShieldPowerUp>();
                shield.damageResist -= 1;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
    }
}
