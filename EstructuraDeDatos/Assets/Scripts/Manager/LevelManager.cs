using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool isGameLoop; //Bool para definir si el nivel es de juego.
    [SerializeField] private QuickSortData quickSortData;
    [SerializeField] private float currentTime;
    public Animator transition;

    void Update()
    {
        if (isGameLoop)
        {
            currentTime += Time.deltaTime;
            currentTime = MathF.Round(currentTime * 100f) / 100f;
        }
    }
    
    public IEnumerator VictoryScreen(float delay) //Pantalla de victoria
    {
        quickSortData.SetNewTime(currentTime);
        
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.StopMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayVictorySound();
        }

        yield return new WaitForSeconds(0.5f); // Espera medio segundo antes de cargar la escena

        SceneManager.LoadScene("Victory");
    }

    public IEnumerator DefeatScreen(float delay) //Pantalla de derrota
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.StopMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayDefeatSound();
        }

        yield return new WaitForSeconds(0.5f); // Espera medio segundo antes de cargar la escena

        SceneManager.LoadScene("Defeat");
    }
}
