using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;
    public void MenuScreen() //Carga la pantalla "Menú"
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void LoadNextLevel() //Carga el primer nivel
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }
    
    public void GameQuit() // Quita el juego
    {
        Application.Quit();
    }
}
