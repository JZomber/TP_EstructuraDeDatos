using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LifeSystem : MonoBehaviour
{
    public int maxLife = 3; // Cantidad máxima de vida
    private int currentLife; // Vida actual
    public Image heartPrefab; // Prefab del corazón
    public Transform heartParent; // Padre para los corazones
    private Stack<Image> hearts = new Stack<Image>(); // Pila de imágenes de los corazones
    public GameObject player; // Referencia al jugador

    void Start()
    {
        currentLife = maxLife; // Configura la vida actual al máximo al inicio
        InstantiateHearts(); // Crea y muestra los corazones
    }

    void InstantiateHearts()
    {
        float offsetX = 100f; // Espacio horizontal entre los corazones (tamaño del corazón)
        for (int i = 0; i < maxLife; i++)
        {
            // Crear una nueva instancia del prefab de corazón
            Image newHeart = Instantiate(heartPrefab, heartParent);

            // Ajustar la posición horizontal del corazón
            Vector3 heartPosition = new Vector3(i * offsetX, 0f, 0f);
            newHeart.transform.localPosition = heartPosition;

            // Activar el objeto de corazón
            newHeart.gameObject.SetActive(true);

            // Agregar el corazón a la pila de corazones
            hearts.Push(newHeart);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentLife -= damageAmount; // Reduce la vida actual según el daño recibido
        currentLife = Mathf.Clamp(currentLife, 0, maxLife); // Asegura que la vida no sea menor que 0 ni mayor que la vida máxima

        // Actualiza la visualización de los corazones
        int heartsToShow = Mathf.Max(currentLife, 0); // Determina cuántos corazones mostrar según la vida actual
        while (hearts.Count > heartsToShow)
        {
            Image heartToRemove = hearts.Pop();
            Destroy(heartToRemove.gameObject);
        }

        if (currentLife <= 0)
        {
            Debug.LogError("Player is already dead!");
            // Destruir el jugador
            //Destroy(player);
            return;
        }
    }
}
