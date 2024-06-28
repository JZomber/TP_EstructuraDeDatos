using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public List<ScoreData> scores = new List<ScoreData>();

    void Start()
    {
        LoadScoresFromJSON();
        SortScoresByCompletionTime();
        PrintScores(); // Imprimir las puntuaciones ordenadas en la consola
    }

    void LoadScoresFromJSON()
    {
        string jsonPath = Application.dataPath + "/Scripts/QuickSort/scores.json";
        Debug.Log("Ruta del archivo JSON: " + jsonPath);

        if (File.Exists(jsonPath))
        {
            string jsonData = File.ReadAllText(jsonPath);
            Debug.Log("Datos JSON cargados: " + jsonData);

            // Deserializar el objeto JSON que contiene la lista de puntuaciones
            ScoreList scoreList = JsonUtility.FromJson<ScoreList>(jsonData);
            scores = scoreList.scores;

            Debug.Log("Puntuaciones cargadas desde el JSON:");
            foreach (var score in scores)
            {
                Debug.Log("Jugador: " + score.playerName + ", Tiempo: " + score.completionTime);
            }
        }
        else
        {
            Debug.LogError("No se encontr� el archivo JSON en la ruta especificada.");
        }
    }

    void SortScoresByCompletionTime()
    {
        Debug.Log("Ordenando puntuaciones...");
        Quicksort(scores, 0, scores.Count - 1);
        Debug.Log("Puntuaciones ordenadas.");
    }

    void Quicksort(List<ScoreData> arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            Quicksort(arr, low, pi - 1);
            Quicksort(arr, pi + 1, high);
        }
    }

    int Partition(List<ScoreData> arr, int low, int high)
    {
        float pivot = arr[high].completionTime;
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (arr[j].completionTime < pivot)
            {
                i++;
                ScoreData temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        ScoreData temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;

        return i + 1;
    }

    void PrintScores()
    {
        Debug.Log("Puntuaciones ordenadas:");
        foreach (var score in scores)
        {
            Debug.Log("Jugador: " + score.playerName + ", Tiempo: " + score.completionTime);
        }
    }
}

[System.Serializable]
public class ScoreData
{
    public string playerName;
    public float completionTime;
}

[System.Serializable]
public class ScoreList
{
    public List<ScoreData> scores;
}

