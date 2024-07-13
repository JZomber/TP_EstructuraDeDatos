using System.Collections;
using System.Collections.Generic;
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
        //StartCoroutine(LoadLevel(1));
        StartCoroutine(LoadScene("Level_1"));
    }

    public void LoadCodex() // Carga la escena del Codex
    {
        StartCoroutine(LoadScene("Codex"));
    }

    public void LoadScore() // Carga la escena de Score
    {
        StartCoroutine(LoadScene("Score"));
    }

    IEnumerator MenuScreen(string str) // Carga la pantalla "Menú"
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(str);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
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

    public void GameQuit() // Quita el juego
    {
        Application.Quit();
    }
}
