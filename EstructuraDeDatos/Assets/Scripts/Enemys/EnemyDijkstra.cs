using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDijkstra : MonoBehaviour
{
    public Grafo grafo;
    public Node currentNode;
    public float speed = 5f;
    private Queue<Node> path;
    private Vector3 targetPosition;
    private HashSet<Node> visitedNodes;

    private bool isAlive = true;
    [SerializeField] private int health;
    [SerializeField] private Animator animator;
    
    void Start()
    {
        path = new Queue<Node>();
        visitedNodes = new HashSet<Node>();
        transform.position = currentNode.Position;
        FindNextPath();
        
        animator.SetBool("isAlive", true);
        animator.SetBool("isRunning", true);
    }

    void Update()
    {
        if (isAlive)
        {
            if (path.Count > 0)
            {
                MoveAlongPath();
            }
            else
            {
                FindNextPath();
            }
        }
    }

    private void MoveAlongPath()
    {
        if (targetPosition == Vector3.zero)
        {
            currentNode = path.Dequeue();
            targetPosition = currentNode.Position;
            visitedNodes.Add(currentNode);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = Vector3.zero;
        }
    }

    private void FindNextPath()
    {
        var shortestPaths = Dijkstra.FindShortestPaths(currentNode, grafo.Nodes); // Returns Distance
        Node nextNode = null;
        float shortestDistance = float.MaxValue; // inf

        foreach (var edge in currentNode.Edges)
        {
            if (shortestPaths.ContainsKey(edge.Target) && shortestPaths[edge.Target] < shortestDistance && !visitedNodes.Contains(edge.Target))
            {
                shortestDistance = shortestPaths[edge.Target]; // Shortest distance => Target Node's distance
                nextNode = edge.Target;
                //Debug.Log($"SIGUIENTE NODO {edge.Target.Name}");
            }
        }

        if (nextNode != null)
        {
            path.Enqueue(nextNode);
        }
        else
        {
            visitedNodes.Clear();
            path.Enqueue(currentNode);
            grafo.ReassignEdgeCost();
            FindNextPath();
            //Debug.LogError("REINICIO DE NODOS");
        }
    }
    
    public void EnemyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isAlive = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            animator.SetBool("isAlive", isAlive);
            animator.SetBool("isRunning", isAlive);
            animator.SetTrigger("isDead");
        }
    }
}
