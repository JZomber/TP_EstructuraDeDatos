using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int maxLife = 3; // Cantidad máxima de vida
    private int currentLife; // Vida actual
    public Image[] hearts; // Array de imágenes de los corazones
    public GameObject _player;

    void Start()
    {
        currentLife = maxLife; // Configura la vida actual al máximo al inicio
        UpdateHearts(); // Actualiza la visualización de los corazones
    }

    // Método para actualizar la visualización de los corazones
    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Si el índice es menor que la vida actual, muestra el corazón lleno, de lo contrario, muestra el corazón vacío
            if (i < currentLife)
            {
                hearts[i].enabled = true; // Mostrar corazón lleno
            }
            else
            {
                hearts[i].enabled = false; // Mostrar corazón vacío
            }

            if (currentLife == 0)
            {
                _player.SetActive(false);
            }
        }
    }

    // Método para reducir la vida del jugador
    public void TakeDamage(int damageAmount)
    {
        currentLife -= damageAmount; // Reduce la vida actual según el daño recibido
        currentLife = Mathf.Clamp(currentLife, 0, maxLife); // Asegura que la vida no sea menor que 0 ni mayor que la vida máxima
        UpdateHearts(); // Actualiza la visualización de los corazones

        // Si la vida llega a cero, puedes hacer algo aquí, como reiniciar el nivel o mostrar un mensaje de "Game Over"
    }

    // Método para aumentar la vida del jugador (si es necesario)
    public void GainLife(int lifeAmount, GameObject other)
    {
        if (currentLife < maxLife) //Chequeo de que no tenga vida máxima antes de agregar 1 de vida
        {
            currentLife += lifeAmount; // Aumenta la vida actual según la cantidad recibida
            currentLife = Mathf.Clamp(currentLife, 0, maxLife); // Asegura que la vida no sea menor que 0 ni mayor que la vida máxima
            UpdateHearts(); // Actualiza la visualización de los corazones
            
            other.SetActive(false); //Desactiva el objeto con el que interactuó el player
        }
    }
}
