using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grafo : IGrafoTDA
{
    public Dictionary<string, Node> Nodes = new Dictionary<string, Node>();


    public void Initialize(List<Transform> nodeTransforms, List<(int, int)> connections)
    {
        for (int i = 0; i < nodeTransforms.Count; i++)
        {
            AddNode(i.ToString(), nodeTransforms[i].position);
        }

        foreach (var connection in connections)
        {
            int from = connection.Item1;
            int to = connection.Item2;
            float cost = Random.Range(1.0f, 10.0f);
            AddEdge(from.ToString(), to.ToString(), cost);
        }
    }

    public void AddNode(string name, Vector3 position)
    {
        Nodes[name] = new Node(name, position);
    }

    public void AddEdge(string fromNode, string toNode, float cost)
    {
        Node from = Nodes[fromNode];
        Node to = Nodes[toNode];
        from.Edges.Add(new Edge(to, cost));
    }

    public void ReassignEdgeCost()
    {
        foreach (var node in Nodes.Values)
        {
            foreach (var edge in node.Edges)
            {
                float cost = Random.Range(1.0f, 10.0f); 
                edge.ReAssignCost(cost);
            }
        }
    }
}
