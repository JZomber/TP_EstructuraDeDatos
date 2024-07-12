using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    public static BackgroundMusicManager Instance;

    public AudioSource audioSource;
    public AudioClip menuMusic;
    public AudioClip gameplayMusic;
    public AudioClip victorySound;
    public AudioClip defeatSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource.loop = true;
        PlayMenuMusic();
    }

    public void PlayMenuMusic()
    {
        if (audioSource.clip != menuMusic)
        {
            audioSource.clip = menuMusic;
            audioSource.Play();
        }
    }

    public void PlayGameplayMusic()
    {
        if (audioSource.clip != gameplayMusic)
        {
            audioSource.clip = gameplayMusic;
            audioSource.Play();
        }
    }

    public void PlayVictorySound()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = victorySound;
        audioSource.Play();
    }

    public void PlayDefeatSound()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = defeatSound;
        audioSource.Play();
    }
}