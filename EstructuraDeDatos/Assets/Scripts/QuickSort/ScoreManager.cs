using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public QuickSortData quickSortData;
    public TextMeshProUGUI[] scoreTexts;

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        // Crear una lista de ScoreData a partir del QuickSortData
        List<ScoreData> scores = new List<ScoreData>
        {
            new ScoreData { playerName = quickSortData.PlayerName1, completionTime = quickSortData.ScorePlayer1 },
            new ScoreData { playerName = quickSortData.PlayerName2, completionTime = quickSortData.ScorePlayer2 },
            new ScoreData { playerName = quickSortData.PlayerName3, completionTime = quickSortData.ScorePlayer3 },
            new ScoreData { playerName = quickSortData.PlayerName4, completionTime = quickSortData.ScorePlayer4 },
            new ScoreData { playerName = quickSortData.PlayerName5, completionTime = quickSortData.ScorePlayer5 },
            new ScoreData { playerName = "Player", completionTime = quickSortData.mainPlayerTime }
        };

        // Ordenar los puntajes usando QuickSort
        Quicksort(scores, 0, scores.Count - 1);

        // Mostrar los 6 mejores puntajes
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scores.Count)
            {
                scoreTexts[i].text = scores[i].playerName + ": " + scores[i].completionTime.ToString("F2") + "s";
            }
            else
            {
                scoreTexts[i].text = "";
            }
        }
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
}

[System.Serializable]
public class ScoreData
{
    public string playerName;
    public float completionTime;
}
