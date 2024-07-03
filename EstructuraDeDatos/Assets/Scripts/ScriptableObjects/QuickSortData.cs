using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewQuickSortData", menuName = "Data/QuickSortData")]
public class QuickSortData : ScriptableObject
{
    // VARIBLES QUE SER�N RELACIONADAS AL PLAYER
    //==========================================
    
    [Header("Main Player")]
    [SerializeField] private float mainPlayerRecordTime; // Variable para al macenar el mejor tiempo del jugador.

    public float mainPlayerTime; // Variable para almacenar el tiempo que consigui� el jugador.

    public float MainPlayerRecordTime => mainPlayerRecordTime; // Se referencia una variable p�blica del record actual del jugador.

    public void SetNewRecord(float record) // Se utiliza para setear un nuevo record de tiempo al player.
    {
        mainPlayerRecordTime = record;
    }
    
    // VARIABLES INVENTADAS PARA EL QUICKSORT (NO SE PUEDEN MODIFICAR DESDE OTRO SCRIPT, SOLO DESDE INSPECTOR)
    //========================================================================================================
    [Header("Player 1")]
    [SerializeField] private string playerName1 = "Charizard";
    [SerializeField] private float scorePlayer1 = 30.5f;
    
    [Header("Player 2")]
    [SerializeField] private string playerName2 = "Waifu62";
    [SerializeField] private float scorePlayer2 = 25.0f;
    
    [Header("Player 3")]
    [SerializeField] private string playerName3 = "MotoMoto";
    [SerializeField] private float scorePlayer3 = 40.2f;
    
    [Header("Player 4")]
    [SerializeField] private string playerName4 = "Sape";
    [SerializeField] private float scorePlayer4 = 22.8f;
    
    [Header("Player 5")]
    [SerializeField] private string playerName5 = "Akira Toriyama";
    [SerializeField] private float scorePlayer5 = 30.5f;
    
    [Header("Player 6")]
    [SerializeField] private string playerName6 = "Agumon";
    [SerializeField] private float scorePlayer6 = 22.8f;

    // REFERENCIAS DE LAS VARIABLES PRIVADAS CON P�BLICAS
    //====================================================
    public string PlayerName1 => playerName1;
    public float ScorePlayer1 => scorePlayer1;
    
    public string PlayerName2 => playerName2;
    public float ScorePlayer2 => scorePlayer2;
    
    public string PlayerName3 => playerName3;
    public float ScorePlayer3 => scorePlayer3;
    
    public string PlayerName4 => playerName4;
    public float ScorePlayer4 => scorePlayer4;
    
    public string PlayerName5 => playerName5;
    public float ScorePlayer5 => scorePlayer5;
    
    public string PlayerName6 => playerName6;
    public float ScorePlayer6 => scorePlayer6;
}
