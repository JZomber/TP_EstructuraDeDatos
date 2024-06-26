using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodexController : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject enemyCardPrefab;
    public Button sortHealthAscButton;
    public Button sortHealthDescButton;
    public Button sortNameButton;

    private ABB arbol;

    void Start()
    {
        arbol = new ABB();
        EnemyScript[] enemies = FindObjectsOfType<EnemyScript>();

        foreach (var enemy in enemies)
        {
            arbol.AgregarElem(enemy);
        }

        sortHealthAscButton.onClick.AddListener(SortByHealthAsc);
        sortHealthDescButton.onClick.AddListener(SortByHealthDesc);
        sortNameButton.onClick.AddListener(SortByName);

        SortByHealthAsc(); // Ordenar por defecto al iniciar
    }

    public void SortByHealthAsc()
    {
        ClearContent();
        arbol.RecorrerEnOrdenAscendente(AddEnemyCard);
    }

    public void SortByHealthDesc()
    {
        ClearContent();
        arbol.RecorrerEnOrdenDescendente(AddEnemyCard);
    }

    public void SortByName()
    {
        ClearContent();
        arbol.RecorrerPorNombre(AddEnemyCard);
    }

    void AddEnemyCard(EnemyScript enemy)
    {
        GameObject newCard = Instantiate(enemyCardPrefab, contentPanel);

        // Asignar valores directamente en los componentes de la carta
        TextMeshProUGUI[] texts = newCard.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var text in texts)
        {
            if (text.name == "NameText")
            {
                text.text = enemy.name;
            }
            else if (text.name == "HealthText")
            {
                text.text = enemy.health.ToString();
            }
        }

        Image[] images = newCard.GetComponentsInChildren<Image>();
        foreach (var image in images)
        {
            if (image.name == "EnemyImage")
            {
                // Asigna la imagen del enemigo aquí si tienes una
                // image.sprite = enemy.sprite;
            }
        }
    }

    void ClearContent()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }
    }
}