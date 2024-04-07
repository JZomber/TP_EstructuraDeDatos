// Ejemplo de cómo dañar al jugador desde otro script
// Asume que hay una colisión o algún otro evento que requiere dañar al jugador
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private LifeSystem lifeSystem;

    void Start()
    {
        lifeSystem = FindObjectOfType<LifeSystem>(); // Encuentra el script LifeSystem
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Si el jugador colisiona con un enemigo
        {
            lifeSystem.TakeDamage(1); // Reduce la vida del jugador en 1
            Destroy(other.gameObject); // Destruye el objeto enemigo
        }
    }
}