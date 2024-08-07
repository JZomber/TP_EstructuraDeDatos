using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodexController : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform cardContainer1;
    public Transform cardContainer2;
    public Transform cardContainer3;
    public Button sortHealthAscButton;
    public Button sortHealthDescButton;
    public Button sortNameButton;

    public GameObject[] enemyPrefabs;

    private ABB enemyTree;
    private SoundManager soundManager;

    void Start()
    {
        // Obtener la instancia del SoundManager en la escena
        soundManager = SoundManager.Instance;

        if (soundManager == null)
        {
            Debug.LogError("SoundManager no est� asignado en CodexController.");
        }

        enemyTree = new ABB();

        // Agregar enemigos al �rbol desde los prefabs
        foreach (var enemyPrefab in enemyPrefabs)
        {
            EnemyScript enemyScript = enemyPrefab.GetComponent<EnemyScript>();
            if (enemyScript != null)
            {
                enemyTree.AgregarElem(new EnemyCard(enemyScript.enemyName, (int)enemyScript.health, enemyScript.EnemySprite));
            }
        }

        // Configurar botones de ordenamiento
        sortHealthAscButton.onClick.AddListener(SortByHealthAsc);
        sortHealthDescButton.onClick.AddListener(SortByHealthDesc);
        sortNameButton.onClick.AddListener(SortByName);

        // Mostrar la lista inicialmente ordenada por salud ascendente (menor a mayor vida)
        MostrarEnemigosOrdenadosPorSaludAsc();
    }

    void MostrarEnemigosOrdenadosPorSaludAsc()
    {
        LimpiarCodex();

        List<EnemyCard> enemies = enemyTree.InOrder(); // Orden ascendente (menor a mayor vida)
        for (int i = 0; i < enemies.Count && i < 3; i++)
        {
            CrearCartaEnemigo(enemies[i], i);
        }
    }

    void MostrarEnemigosOrdenadosPorSaludDesc()
    {
        LimpiarCodex();

        List<EnemyCard> enemies = enemyTree.InOrderDesc(); // Orden descendente (mayor a menor vida)
        for (int i = 0; i < enemies.Count && i < 3; i++)
        {
            CrearCartaEnemigo(enemies[i], i);
        }
    }

    void MostrarEnemigosOrdenadosPorNombre()
    {
        LimpiarCodex();

        List<EnemyCard> enemies = enemyTree.InOrderByName(); // Orden por nombre
        for (int i = 0; i < enemies.Count && i < 3; i++)
        {
            CrearCartaEnemigo(enemies[i], i);
        }
    }

    void CrearCartaEnemigo(EnemyCard enemy, int index)
    {
        GameObject card = Instantiate(cardPrefab);
        CardInfo cardInfo = card.GetComponent<CardInfo>();
        cardInfo.ShowInfo(enemy);

        switch (index)
        {
            case 0:
                card.transform.SetParent(cardContainer1, false);
                break;
            case 1:
                card.transform.SetParent(cardContainer2, false);
                break;
            case 2:
                card.transform.SetParent(cardContainer3, false);
                break;
            default:
                break;
        }
    }

    void LimpiarCodex()
    {
        foreach (Transform child in cardContainer1)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in cardContainer2)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in cardContainer3)
        {
            Destroy(child.gameObject);
        }
    }

    void SortByHealthAsc()
    {
        if (soundManager != null && soundManager.buttonClickSound != null)
        {
            SoundManager.Instance.soundEffectSource.volume = 0.2f;
            soundManager.PlayButtonClickSound();
            SoundManager.Instance.soundEffectSource.volume = 0.5f;
        }
        MostrarEnemigosOrdenadosPorSaludAsc(); // Ordenar de menor a mayor vida
    }

    void SortByHealthDesc()
    {
        if (soundManager != null && soundManager.buttonClickSound != null)
        {
            SoundManager.Instance.soundEffectSource.volume = 0.2f;
            soundManager.PlayButtonClickSound();
            SoundManager.Instance.soundEffectSource.volume = 0.5f;
        }
        MostrarEnemigosOrdenadosPorSaludDesc(); // Ordenar de mayor a menor vida
    }

    void SortByName()
    {
        if (soundManager != null && soundManager.buttonClickSound != null)
        {
            SoundManager.Instance.soundEffectSource.volume = 0.2f;
            soundManager.PlayButtonClickSound();
            SoundManager.Instance.soundEffectSource.volume = 0.5f;
        }
        MostrarEnemigosOrdenadosPorNombre(); // Ordenar por nombre
    }
}
