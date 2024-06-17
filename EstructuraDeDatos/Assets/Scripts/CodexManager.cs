using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexManager : MonoBehaviour
{
    private static CodexManager Instance;
    public static CodexManager instance { get { return Instance; } }
    [SerializeField] CardInfo[] CardList;
    int index = 0;

    public void FillInfo(EnemyScript enemy)
    {
        CardList[index].InfoEnemy = enemy;
        CardList[index].Showinfo();
        index++;
    }
}