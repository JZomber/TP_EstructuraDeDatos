using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQueue<T>
{
    void InitQueue(int size);

    void Acolar(T obj);
    T DesAcolar();
    T First();
    
    bool isQueueEmpty();
}
