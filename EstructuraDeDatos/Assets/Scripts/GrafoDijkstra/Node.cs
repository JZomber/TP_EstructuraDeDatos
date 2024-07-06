using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public string Name { get; private set; }
    public Vector3 Position { get; private set; }

    public List<Edge> Edges = new List<Edge>();

    public Node(string name, Vector3 position)
    {
        Name = name;
        Position = position;
    }
}

public class Edge
{
    public Node Target { get; private set; }
    public float Cost { get; private set; }

    public Edge(Node target, float cost)
    {
        Target = target;
        Cost = cost;
    }

    public void ReAssignCost(float cost)
    {
        Cost = cost;
    }
}
