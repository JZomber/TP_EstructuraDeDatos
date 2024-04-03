using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int maxLife = 3; // Cantidad m�xima de vida
    private int currentLife; // Vida actual
    public Image[] hearts; // Array de im�genes de los corazones

    void Start()
    {
        currentLife = maxLife; // Configura la vida actual al m�ximo al inicio
        UpdateHearts(); // Actualiza la visualizaci�n de los corazones
    }

    // M�todo para actualizar la visualizaci�n de los corazones
    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Si el �ndice es menor que la vida actual, muestra el coraz�n lleno, de lo contrario, muestra el coraz�n vac�o
            if (i < currentLife)
            {
                hearts[i].enabled = true; // Mostrar coraz�n lleno
            }
            else
            {
                hearts[i].enabled = false; // Mostrar coraz�n vac�o
            }
        }
    }

    // M�todo para reducir la vida del jugador
    public void TakeDamage(int damageAmount)
    {
        currentLife -= damageAmount; // Reduce la vida actual seg�n el da�o recibido
        currentLife = Mathf.Clamp(currentLife, 0, maxLife); // Asegura que la vida no sea menor que 0 ni mayor que la vida m�xima
        UpdateHearts(); // Actualiza la visualizaci�n de los corazones

        // Si la vida llega a cero, puedes hacer algo aqu�, como reiniciar el nivel o mostrar un mensaje de "Game Over"
    }

    // M�todo para aumentar la vida del jugador (si es necesario)
    public void GainLife(int lifeAmount)
    {
        currentLife += lifeAmount; // Aumenta la vida actual seg�n la cantidad recibida
        currentLife = Mathf.Clamp(currentLife, 0, maxLife); // Asegura que la vida no sea menor que 0 ni mayor que la vida m�xima
        UpdateHearts(); // Actualiza la visualizaci�n de los corazones
    }
}
