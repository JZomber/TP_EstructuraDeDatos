using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int maxLife = 3; // Cantidad máxima de vida
    private int currentLife; // Vida actual
    public Image heartPrefab; // Prefab del corazón
    public Transform heartParent; // Padre para los corazones
    private Stack_TDAPila<Image> hearts = new Stack_TDAPila<Image>(); // Pila de imágenes de los corazones
    public GameObject player; // Referencia al jugador

    
    void Start()
    {
        currentLife = maxLife; // Configura la vida actual al máximo al inicio
        hearts.InicializarPila(maxLife); // Inicializa la pila con el tamaño máximo de vida
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

            // Agregar el corazón a la pila de corazones
            hearts.Apilar(newHeart);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentLife -= damageAmount; // Reduce la vida actual según el daño recibido

        // Actualiza la visualización de los corazones
        UpdateHeartDisplay();

        if (currentLife <= 0)
        {
            Debug.LogError("Player is already dead!");

            player.GetComponent<PlayerMov>().isDead = true;
            player.GetComponent<Animator>().SetTrigger("isDead");
            return;
        }
    }

    public void UpdateHeartDisplay()
    {
        // Determina cuántos corazones mostrar según la vida actual
        int heartsToShow = Mathf.Max(currentLife, 0);

        // Muestra o esconde los corazones según la vida actual
        while (hearts.Count() > heartsToShow)
        {
            Image heartToRemove = hearts.Tope();
            hearts.Desapilar();
            heartToRemove.gameObject.SetActive(false);
        }
        while (hearts.Count() < heartsToShow)
        {
            // Crear una nueva instancia del prefab de corazón
            Image newHeart = Instantiate(heartPrefab, heartParent);

            // Ajustar la posición horizontal del corazón
            Vector3 heartPosition = new Vector3((hearts.Count() * 100f), 0f, 0f);
            newHeart.transform.localPosition = heartPosition;

            // Activar el objeto de corazón
            newHeart.gameObject.SetActive(true);

            // Agregar el corazón a la pila de corazones
            hearts.Apilar(newHeart);
        }
    }
}