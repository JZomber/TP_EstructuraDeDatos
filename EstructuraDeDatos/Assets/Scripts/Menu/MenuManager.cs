using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;

    public void LoadMenu()
    {
        StartCoroutine(MenuScreen("Menu"));
    }

    public void LoadNextLevel() // Carga el primer nivel
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadCodex() // Carga la escena del Codex
    {
        StartCoroutine(LoadScene("Codex"));
    }

    public void LoadScore() // Carga la escena de Score
    {
        StartCoroutine(LoadScene("Score"));
    }

    public void LoadVictory() // Carga la escena de Victoria
    {
        StartCoroutine(LoadVictoryScene("Victory"));
    }

    public void LoadDefeat() // Carga la escena de Derrota
    {
        StartCoroutine(LoadDefeatScene("Defeat"));
    }

    public void RestartGame() // Reinicia el nivel
    {
        StartCoroutine(RestartLevel(1)); // Aquí se asume que el nivel a reiniciar es el nivel 1
    }

    IEnumerator MenuScreen(string str) // Carga la pantalla "Menú"
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayMenuMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(str);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayGameplayMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadVictoryScene(string sceneName)
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayVictorySound();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadDefeatScene(string sceneName)
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayDefeatSound();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator RestartLevel(int levelIndex)
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayGameplayMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }

    public void GameQuit() // Quita el juego
    {
        Application.Quit();
    }
}