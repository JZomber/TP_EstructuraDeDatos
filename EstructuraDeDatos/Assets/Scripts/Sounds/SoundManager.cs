using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource soundEffectSource;

    // Declaración de todos los AudioClips necesarios para los efectos de sonido
    public AudioClip playerShootSound;
    public AudioClip playerTakeDamageSound;
    public AudioClip playerHealSound;
    public AudioClip playerActivateShieldSound;
    public AudioClip playerActivatePowerUpSound;
    public AudioClip buttonClickSound;
    public AudioClip cardPickUpSound;
    public AudioClip cardUsePowerSound;
    public AudioClip enemyShootSound;

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

    // Métodos para reproducir cada tipo de efecto de sonido
    public void PlayPlayerShootSound()
    {
        soundEffectSource.PlayOneShot(playerShootSound);
    }

    public void PlayPlayerTakeDamageSound()
    {
        soundEffectSource.PlayOneShot(playerTakeDamageSound);
    }

    public void PlayPlayerHealSound()
    {
        soundEffectSource.PlayOneShot(playerHealSound);
    }

    public void PlayPlayerActivateShieldSound()
    {
        soundEffectSource.PlayOneShot(playerActivateShieldSound);
    }

    public void PlayPlayerActivatePowerUpSound()
    {
        soundEffectSource.PlayOneShot(playerActivatePowerUpSound);
    }

    public void PlayButtonClickSound()
    {
        soundEffectSource.PlayOneShot(buttonClickSound);
    }

    public void PlayCardPickUpSound()
    {
        soundEffectSource.PlayOneShot(cardPickUpSound);
    }

    public void PlayCardUsePowerSound()
    {
        soundEffectSource.PlayOneShot(cardUsePowerSound);
    }

    public void PlayEnemyShootSound()
    {
        soundEffectSource.PlayOneShot(enemyShootSound);
    }
}
