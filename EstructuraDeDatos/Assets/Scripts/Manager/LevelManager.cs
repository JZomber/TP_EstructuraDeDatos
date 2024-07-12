using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool isGameLoop; // Bool para definir si el nivel es de juego (para evitar "Message error" en escenas de prueba)
    [SerializeField] private GameObject player; // Referencia al player
    [SerializeField] private GameObject doors; // Referencia a las puertas del nivel
    [SerializeField] private GameObject holderWaypoints; // Objeto que almacena las posiciones a donde "teletransportar" al player
    [SerializeField] private Transform[] waypoints; // Array de posiciones
    private int totalWaypoints;
    private int indexWaypoint;
    public Animator transition; // Transición entre escenas
    public int enemyCounter; // Enemigos eliminados
    public QuickSortData quickSortData;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        if (isGameLoop) // Si es un nivel de juego
        {
            indexWaypoint = 0;
            totalWaypoints = holderWaypoints.transform.childCount;
            waypoints = new Transform[totalWaypoints];

            for (int i = 0; i < totalWaypoints; i++)
            {
                waypoints[i] = holderWaypoints.transform.GetChild(i).transform;
            }

            startTime = Time.time; // Inicializar el tiempo de inicio del nivel
        }
    }

    void Update()
    {
        if (isGameLoop) // Si es un nivel de juego
        {
            if (enemyCounter >= 4)
            {
                doors.SetActive(false);
            }
        }
    }

    public void TpWaypoint() // Posiciones a donde llevar al player cada vez que termina una sala
    {
        player.transform.position = waypoints[indexWaypoint].transform.position;
        indexWaypoint++;
        enemyCounter = 0;
        doors.SetActive(true);
    }

    public IEnumerator VictoryScreen(float delay) // Pantalla de victoria
    {
        float playerTime = Time.time - startTime; // Calcular el tiempo del jugador
        quickSortData.mainPlayerTime = playerTime; // Actualizar el tiempo del jugador en QuickSortData

        if (playerTime < quickSortData.MainPlayerRecordTime)
        {
            quickSortData.SetNewRecord(playerTime); // Actualizar el récord si es un nuevo mejor tiempo
        }

        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayVictorySound();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Victory");
    }

    public IEnumerator DefeatScreen(float delay) // Pantalla de derrota
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayDefeatSound();
        }

        yield return new WaitForSeconds(delay);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Defeat");
    }
}
