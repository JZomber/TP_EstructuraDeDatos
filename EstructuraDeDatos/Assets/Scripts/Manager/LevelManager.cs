using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool isGameLoop; //Bool para definir si el nivel es de juego (para evitar "Message error" en escenas de prueba)

    [SerializeField] private GameObject player; //Referencia al player

    [SerializeField] private GameObject doors; //Referencia a las puertas del nivel

    [SerializeField] private GameObject holderWaypoints; //Objeto que almacena las pocisiones a donde "teletransportar" al player
    [SerializeField] private Transform[] waypoints; //Array de posiciones
    private int totalWaypoints;
    private int indexWaypoint;

    public Animator transition; //Transición entre escenas

    [SerializeField] private int killsRequired = 4;

    public int enemyCounter; //Enemigos elminados

    void Start()
    {
        if (isGameLoop) //Si es un nivel de juego
        {
            indexWaypoint = 0;

            totalWaypoints = holderWaypoints.transform.childCount;
            waypoints = new Transform[totalWaypoints];

            for (int i = 0; i < totalWaypoints; i++)
            {
                waypoints[i] = holderWaypoints.transform.GetChild(i).transform;
            }
        }
    }

    void Update()
    {
        if (isGameLoop) //Si es un nivel de juego
        {
            if (enemyCounter >= killsRequired)
            {
                doors.SetActive(false);
            }
        }
    }

    public void TpWaypoint() //Posiciones a donde llevar al player cada vez que termina una sala
    {
        player.transform.position = new Vector3(waypoints[indexWaypoint].transform.position.x, waypoints[indexWaypoint].transform.position.y, 0);

        indexWaypoint++;
        enemyCounter = 0;
        doors.SetActive(true);
    }

    public IEnumerator VictoryScreen(float delay) //Pantalla de victoria
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.StopMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Victory");

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayVictorySound();
        }
    }

    public IEnumerator DefeatScreen(float delay) //Pantalla de derrota
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.StopMusic();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Defeat");

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayDefeatSound();
        }
    }
}
