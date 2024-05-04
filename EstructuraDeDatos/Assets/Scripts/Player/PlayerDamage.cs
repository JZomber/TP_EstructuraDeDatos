using System;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private LifeSystem lifeSystem;
    private bool canTakeDamage = true;

    public float damageCooldownTime = 2f; // Tiempo de espera antes de volver a tomar da�o

    void Start()
    {
        lifeSystem = FindObjectOfType<LifeSystem>(); // Encuentra el script LifeSystem
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && canTakeDamage) // Si el jugador colisiona con un enemigo y puede tomar da�o
        {
            lifeSystem.TakeDamage(1); // Reduce la vida del jugador en 1
            canTakeDamage = false; // Deshabilita la capacidad de tomar da�o temporalmente
            StartCoroutine(ResetDamageCooldown()); // Espera un tiempo antes de permitir que el jugador tome da�o nuevamente
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Trap") && canTakeDamage) //Si el jugador colisiona y/o se queda en la trampa, recibe da�o
        {
            lifeSystem.TakeDamage(1); // Reduce la vida del jugador en 1
            canTakeDamage = false; // Deshabilita la capacidad de tomar da�o temporalmente
            StartCoroutine(ResetDamageCooldown()); // Espera un tiempo antes de permitir que el jugador tome da�o nuevamente
        }
    }

    System.Collections.IEnumerator ResetDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldownTime); // Espera el tiempo especificado
        canTakeDamage = true; // Permite que el jugador tome da�o nuevamente
    }
}