using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABB : MonoBehaviour
{

    public class NodoABB
    {
        public EnemyScript enemy;
        public NodoABB hijoIzq;
        public NodoABB hijoDer;

        public NodoABB(EnemyScript enemy)
        {
            this.enemy = enemy;
            hijoIzq = null;
            hijoDer = null;
        }
    }

    private NodoABB raiz;

    public ABB()
    {
        raiz = null;
    }

    public void AgregarElem(EnemyScript enemy)
    {
        raiz = AgregarRecursivo(raiz, enemy);
    }

    private NodoABB AgregarRecursivo(NodoABB nodo, EnemyScript enemy)
    {
        if (nodo == null)
        {
            return new NodoABB(enemy);
        }

        if (enemy.health < nodo.enemy.health ||
            (enemy.health == nodo.enemy.health && string.Compare(enemy.name, nodo.enemy.name) < 0))
        {
            nodo.hijoIzq = AgregarRecursivo(nodo.hijoIzq, enemy);
        }
        else
        {
            nodo.hijoDer = AgregarRecursivo(nodo.hijoDer, enemy);
        }

        return nodo;
    }

    public void RecorrerEnOrdenAscendente(Action<EnemyScript> callback)
    {
        //GameObject.Find("CodexManager").GetComponent<CodexManager>().FillInfo(nodo);
        RecorrerAscendenteRecursivo(raiz, callback);
    }

    private void RecorrerAscendenteRecursivo(NodoABB nodo, Action<EnemyScript> callback)
    {
        if (nodo != null)
        {
            RecorrerAscendenteRecursivo(nodo.hijoIzq, callback);
            callback(nodo.enemy);
            RecorrerAscendenteRecursivo(nodo.hijoDer, callback);
        }
    }

    public void RecorrerEnOrdenDescendente(Action<EnemyScript> callback)
    {
        RecorrerDescendenteRecursivo(raiz, callback);
    }

    private void RecorrerDescendenteRecursivo(NodoABB nodo, Action<EnemyScript> callback)
    {
        if (nodo != null)
        {
            RecorrerDescendenteRecursivo(nodo.hijoDer, callback);
            callback(nodo.enemy);
            RecorrerDescendenteRecursivo(nodo.hijoIzq, callback);
        }
    }

    public void RecorrerPorNombre(Action<EnemyScript> callback)
    {
        // Crear una lista temporal para ordenar por nombre
        List<EnemyScript> enemies = new List<EnemyScript>();
        RecogerEnemigos(raiz, enemies);
        enemies.Sort((e1, e2) => string.Compare(e1.name, e2.name));

        foreach (var enemy in enemies)
        {
            callback(enemy);
        }
    }

    private void RecogerEnemigos(NodoABB nodo, List<EnemyScript> enemies)
    {
        if (nodo != null)
        {
            enemies.Add(nodo.enemy);
            RecogerEnemigos(nodo.hijoIzq, enemies);
            RecogerEnemigos(nodo.hijoDer, enemies);
        }
    }
}