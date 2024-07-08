using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra
{
    public static Dictionary<Node, float> FindShortestPaths(Node startNode, Dictionary<string, Node> allNodes)
    {
        var distances = new Dictionary<Node, float>();
        var priorityQueue = new PriorityQueue<Node>();

        foreach (var node in allNodes.Values)
        {
            distances[node] = float.MaxValue; // Set nodes dist to (inf)
        }

        distances[startNode] = 0;
        priorityQueue.Enqueue(startNode, 0);

        while (priorityQueue.Count > 0)
        {
            Node currentNode = priorityQueue.Dequeue(); // Return current node

            foreach (Edge edge in currentNode.Edges)
            {
                float newDist = distances[currentNode] + edge.Cost;
                if (newDist < distances[edge.Target]) // Node distance (float) < Target distance (inf)
                {
                    distances[edge.Target] = newDist;
                    priorityQueue.Enqueue(edge.Target, newDist);
                }
            }
        }

        return distances;
    }
}

public class PriorityQueue<T>
{
    private List<KeyValuePair<T, float>> elements = new List<KeyValuePair<T, float>>();

    public int Count => elements.Count;

    public void Enqueue(T item, float priority)
    {
        elements.Add(new KeyValuePair<T, float>(item, priority));
        elements.Sort((a, b) => a.Value.CompareTo(b.Value));
    }

    public T Dequeue()
    {
        var item = elements[0].Key;
        elements.RemoveAt(0);
        return item;
    }
}