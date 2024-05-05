using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject doors;
    
    [SerializeField] private GameObject holderWaypoints;
    [SerializeField] private Transform[] waypoints;
    private int totalWaypoints;
    private int indexWaypoint;

    public Animator transition;

    public int enemyCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        indexWaypoint = 0;
        
        totalWaypoints = holderWaypoints.transform.childCount;
        waypoints = new Transform[totalWaypoints];

        for (int i = 0; i < totalWaypoints; i++)
        {
            waypoints[i] = holderWaypoints.transform.GetChild(i).transform;
        }
    }
    
    void Update()
    {
        if (enemyCounter >= 4)
        {
            doors.SetActive(false);
        }
    }

    public void TpWaypoint()
    {
        player.transform.position = waypoints[indexWaypoint].transform.position;
        indexWaypoint++;
        enemyCounter = 0;
        doors.SetActive(true);
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
