using System.Collections.Generic;

public class ABB
{
    private NodoABB raiz;

    public void AgregarElem(EnemyCard enemyCard)
    {
        raiz = AgregarRecursivo(raiz, enemyCard);
    }

    private NodoABB AgregarRecursivo(NodoABB nodo, EnemyCard enemyCard)
    {
        if (nodo == null)
        {
            nodo = new NodoABB(enemyCard);
        }
        else if (enemyCard.enemyHealth < nodo.enemyCard.enemyHealth)
        {
            nodo.hijoIzq = AgregarRecursivo(nodo.hijoIzq, enemyCard);
        }
        else if (enemyCard.enemyHealth > nodo.enemyCard.enemyHealth)
        {
            nodo.hijoDer = AgregarRecursivo(nodo.hijoDer, enemyCard);
        }
        return nodo;
    }

    public List<EnemyCard> InOrder()
    {
        List<EnemyCard> lista = new List<EnemyCard>();
        InOrderRecursivo(raiz, lista);
        return lista;
    }

    private void InOrderRecursivo(NodoABB nodo, List<EnemyCard> lista)
    {
        if (nodo != null)
        {
            InOrderRecursivo(nodo.hijoIzq, lista);
            lista.Add(nodo.enemyCard);
            InOrderRecursivo(nodo.hijoDer, lista);
        }
    }

    public List<EnemyCard> InOrderDesc()
    {
        List<EnemyCard> lista = new List<EnemyCard>();
        InOrderDescRecursivo(raiz, lista);
        return lista;
    }

    private void InOrderDescRecursivo(NodoABB nodo, List<EnemyCard> lista)
    {
        if (nodo != null)
        {
            InOrderDescRecursivo(nodo.hijoDer, lista);
            lista.Add(nodo.enemyCard);
            InOrderDescRecursivo(nodo.hijoIzq, lista);
        }
    }

    public List<EnemyCard> InOrderByName()
    {
        List<EnemyCard> lista = new List<EnemyCard>();
        InOrderByNameRecursivo(raiz, lista);
        lista.Sort((x, y) => x.enemyName.CompareTo(y.enemyName));
        return lista;
    }

    private void InOrderByNameRecursivo(NodoABB nodo, List<EnemyCard> lista)
    {
        if (nodo != null)
        {
            InOrderByNameRecursivo(nodo.hijoIzq, lista);
            lista.Add(nodo.enemyCard);
            InOrderByNameRecursivo(nodo.hijoDer, lista);
        }
    }
}

public class NodoABB
{
    public EnemyCard enemyCard;
    public NodoABB hijoIzq;
    public NodoABB hijoDer;

    public NodoABB(EnemyCard card)
    {
        enemyCard = card;
        hijoIzq = null;
        hijoDer = null;
    }
}