using System.Collections.Generic;
using UnityEngine;

public interface IGrafoTDA
{
    void Initialize(List<Transform> nodeTransforms, List<(int, int)> connections);
    void AddNode(string name, Vector3 position);
    void AddEdge(string fromNode, string toNode, float cost);
    void ReassignEdgeCost();
}
