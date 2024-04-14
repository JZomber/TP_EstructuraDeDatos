using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void MenuScreen() //Carga la pantalla "Menú"
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void VictoryScreen() // Carga la pantalla de victoria
    {
        SceneManager.LoadScene("Victory");
    }
    
    public void DefeatScreen() // Carga la pantalla de derrota
    {
        SceneManager.LoadScene("Defeat");
    }
    
    public void LoadFirstLevel() //Carga el primer nivel
    {
        SceneManager.LoadScene("TestScene");
    }
    
    public void LoadSecondLevel() //Carga el segundo nivel
    {
        //SceneManager.LoadScene("NOMBRE_DEl_NIVEL");
    }

    public void GameQuit() // Quita el juego
    {
        Application.Quit();
    }
}
