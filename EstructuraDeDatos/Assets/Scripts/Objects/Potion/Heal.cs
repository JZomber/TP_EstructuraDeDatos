using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int healAmount = 1; // Cantidad de vida a curar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener la instancia de LifeSystem
            LifeSystem lifeSystem = LifeSystem.Instance;

            if (lifeSystem != null)
            {
                // Curar al jugador
                lifeSystem.HealPlayer(healAmount);
            }
            else
            {
                Debug.LogError("No se encontró la instancia de LifeSystem.");
            }

            // Desactivar la pocion
            gameObject.SetActive(false);
        }
    }
}
