using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public Animator transition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public IEnumerator VictoryScreen(float delay)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Victory");
    }

    public IEnumerator DefeatScreen(float delay)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Defeat");
    }
}
