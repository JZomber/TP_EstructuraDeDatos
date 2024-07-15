using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexManager : MonoBehaviour
{
    private static CodexManager Instance;
    public static CodexManager instance { get { return Instance; } }

    [SerializeField] private CardInfo[] CardList;

    private void Awake()
    {
        Instance = this;
    }

    public void FillInfo(EnemyCard enemyCard)
    {
        for (int i = 0; i < CardList.Length; i++)
        {
            CardList[i].ShowInfo(enemyCard);
        }
    }
}