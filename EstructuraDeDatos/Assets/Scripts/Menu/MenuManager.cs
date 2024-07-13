using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;

    // Añadir referencia al SoundManager
    public SoundManager soundManager;

    void Start()
    {
        // Obtener la instancia del SoundManager si no está asignada en el editor
        if (soundManager == null)
        {
            soundManager = FindObjectOfType<SoundManager>();
            if (soundManager == null)
            {
                Debug.LogError("No se encontró el SoundManager en la escena.");
            }
        }
    }

    public void LoadMenu()
    {
        StartCoroutine(MenuScreen("Menu"));
    }

    public void LoadNextLevel() // Carga el primer nivel
    {
        StartCoroutine(StartGame("Level_1"));
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
        StartCoroutine(RestartLevel("Level_1"));
    }

    IEnumerator MenuScreen(string sceneName) // Carga la pantalla "Menú"
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickSound();
        }

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayMenuMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator StartGame(string sceneName)
    {

        if (soundManager != null)
        {
            soundManager.PlayButtonClickSound();
        }

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.StopMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayGameplayMusic();
        }

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadScene(string sceneName)
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickSound();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadVictoryScene(string sceneName)
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickSound();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayVictorySound();
        }
    }

    IEnumerator LoadDefeatScene(string sceneName)
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickSound();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayDefeatSound();
        }
    }

    IEnumerator RestartLevel(string sceneName)
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickSound();
        }

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.StopMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayGameplayMusic();
        }

        SceneManager.LoadScene(sceneName);
    }

    public void GameQuit() // Quita el juego
    {
        Application.Quit();
    }

    public void ShowControls()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickSound();
        }
    }

}