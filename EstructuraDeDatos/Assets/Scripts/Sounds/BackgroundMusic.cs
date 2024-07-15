using System.Collections;
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
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlayGameplayMusic()
    {
        StartCoroutine(PlayMusicWithDelay(gameplayMusic, 1f));
    }

    public void PlayVictorySound()
    {
        StartCoroutine(PlaySoundAfterDelay(victorySound, 1f));
    }

    public void PlayDefeatSound()
    {
        StartCoroutine(PlaySoundAfterDelay(defeatSound, 1f));
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    private IEnumerator PlayMusicWithDelay(AudioClip clip, float delay)
    {
        audioSource.Stop();
        yield return new WaitForSeconds(delay);
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    private IEnumerator PlaySoundAfterDelay(AudioClip clip, float delay)
    {
        audioSource.Stop();
        yield return new WaitForSeconds(delay);
        audioSource.clip = clip;
        audioSource.loop = false;
        audioSource.Play();
    }
}
