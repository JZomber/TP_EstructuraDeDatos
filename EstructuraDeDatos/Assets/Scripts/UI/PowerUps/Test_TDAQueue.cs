using UnityEngine;

public class Test_TDAQueue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QueueTdaCola<int> cola1 = new QueueTdaCola<int>();
        cola1.InitQueue(5);
        
        Debug.Log("Vacia?: " + cola1.IsQueueEmpty());

        cola1.Acolar(7);
        cola1.Acolar(8);
        cola1.Acolar(9);
        cola1.Acolar(4);

        Debug.Log("Vacia?: " + cola1.IsQueueEmpty());

        Debug.Log("Primer Elemento: " + cola1.First());

        while (!cola1.IsQueueEmpty())
        {
            Debug.Log("Desencolando: " + cola1.DesAcolar());
        }

        Debug.Log("Vacia?: " + cola1.IsQueueEmpty());
    }
}
