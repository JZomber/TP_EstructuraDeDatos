using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    private static LifeSystem instance;
    public static LifeSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LifeSystem>();
                if (instance == null)
                {
                    Debug.LogError("No se encontró el componente LifeSystem en la escena.");
                }
            }
            return instance;
        }
    }

    public int maxLife = 3; // Cantidad máxima de vida
    private int currentLife; // Vida actual
    public Image heartPrefab; // Prefab del corazón
    public Transform heartParent; // Padre para los corazones
    private Stack_TDAPila<Image> hearts = new Stack_TDAPila<Image>(); // Pila de imágenes de los corazones
    public GameObject player; // Referencia al jugador
    private float lastHeartXPosition;


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

        // Oculta y elimina el corazón perdido
        if (currentLife < maxLife)
        {
            lastHeartXPosition = hearts.Tope().transform.localPosition.x;
            Image heartToRemove = hearts.Desapilar();
            heartToRemove.gameObject.SetActive(false);
            Destroy(heartToRemove.gameObject);
        }

        if (currentLife <= 0)
        {
            Debug.LogError("Player is already dead!");

            player.GetComponent<PlayerMov>().isDead = true;
            player.GetComponent<Animator>().SetTrigger("isDead");
            return;
        }
    }

    // Restaura la vida del jugador
    public void HealPlayer(int healAmount)
    {
        for (int i = 0; i < healAmount; i++)
        {
            if (currentLife < maxLife)
            {
                Vector3 newPosition = new Vector3(lastHeartXPosition, 0f, 0f);
                Image newHeart = Instantiate(heartPrefab, heartParent);
                newHeart.gameObject.SetActive(true);
                newHeart.transform.localPosition = newPosition;

                hearts.Apilar(newHeart);
                currentLife++;
            }
        }
    }
}
