using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class GrafoManager : MonoBehaviour
{
    public List<Transform> nodeTransforms;
    [SerializeField] private BoxCollider2D roomTrigger;
    
    public GameObject enemyPrefab;
    private Grafo grafo;
    private Grafo extraGrafo;
    private string initialNode = "0";
    List<(int, int)> connections = new List<(int, int)>()
    {
        // (FROM / TO)
        (0, 1), (0, 5),
        (1, 0), (1, 2),
        (2, 1), (2, 3),
        (3, 2), (3, 4), (3, 11),
        (4, 3), (4, 5), (4, 6),
        (5, 4), (5, 0),
        (6, 4), (6, 7), (6, 11),
        (7, 6), (7, 8),
        (8, 7), (8, 9),
        (9, 8), (9, 10),
        (10, 9), (10, 11),
        (11, 10), (11, 6), (11, 3)
    };
    
    void Start()
    {
        
    }

    private void SpawnStarterEnemy()
    {
        grafo = new Grafo();
        grafo.Initialize(nodeTransforms, connections);

        GameObject enemyObject = Instantiate(enemyPrefab);
        EnemyDijkstra enemy = enemyObject.GetComponent<EnemyDijkstra>();
        enemy.grafo = grafo;
        enemy.currentNode = grafo.Nodes[initialNode]; // Starter Node

        StartCoroutine(SpawnExtraEnemy(5f, initialNode));
    }

    private IEnumerator SpawnExtraEnemy(float delay, string index)
    {
        extraGrafo = new Grafo();
        extraGrafo.Initialize(nodeTransforms, connections);
        
        yield return new WaitForSeconds(delay);

        GameObject enemyObject = Instantiate(enemyPrefab);
        EnemyDijkstra enemy = enemyObject.GetComponent<EnemyDijkstra>();
        enemy.grafo = extraGrafo;
        enemy.currentNode = extraGrafo.Nodes[index]; // Starter Node
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnStarterEnemy();
            roomTrigger.enabled = false;
        }
    }
}

// Enemigo dijkstra pueda recibir daño
// Enemigo adicional en el grafo (aparición con delay, ya sea tiempo o que el otro enemigo esté a mitad de vida).
// Audio en general
