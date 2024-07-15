using System.Collections;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] shootingOrig; // Origen de las balas
    [SerializeField] private GameObject bulletPrefab; // Prefab de bullet (enemy)
    private int totalShootOrigin; // Total de orígenes (depende del arma)

    private float coolDown;
    [SerializeField] private float shootCoolDown;

    [SerializeField] private GameObject weapon; // Prefab del arma
    private bool isSmg;
    public bool canShoot = true;
    public bool isWeaponActive = true;

    private SoundManager soundManager;

    void Start()
    {
        if (weapon.name == "BasicSMG")
        {
            isSmg = true;
        }

        coolDown = shootCoolDown; // Cooldown entre disparos

        totalShootOrigin = weapon.transform.childCount; // Obtengo el número de orígenes de balas
        shootingOrig = new Transform[totalShootOrigin]; // Inicializo la lista según la cantidad

        for (int i = 0; i < totalShootOrigin; i++)
        {
            shootingOrig[i] = weapon.transform.GetChild(i).transform; // Obtengo la posición de cada origen
        }

        soundManager = SoundManager.Instance; // Obtener instancia del SoundManager
    }

    void Update()
    {
        coolDown -= Time.deltaTime;

        if (coolDown <= 0f && canShoot && !isSmg)
        {
            for (int i = 0; i < shootingOrig.Length; i++)
            {
                var rotation = shootingOrig[i].rotation;
                rotation *= Quaternion.Euler(0, 0, -90);
                Instantiate(bulletPrefab, shootingOrig[i].position, rotation);
            }

            PlayEnemyShootSound(0.5f); // Reproducir sonido con volumen ajustado

            coolDown = shootCoolDown;
        }
        else if (coolDown <= 0f && canShoot && isSmg)
        {
            StartCoroutine(ShootSMG(0.2f)); // Delay entre disparos

            coolDown = shootCoolDown;
        }
    }

    private IEnumerator ShootSMG(float delay)
    {
        for (int i = 0; i < 3; i++) // Cantidad de veces que disparará el arma (3 disparos - efecto ráfaga)
        {
            yield return new WaitForSeconds(delay);

            var rotation = shootingOrig[0].rotation;
            rotation *= Quaternion.Euler(0, 0, -90);
            Instantiate(bulletPrefab, shootingOrig[0].position, rotation);
        }

        PlayEnemyShootSound(0.5f); // Reproducir sonido con volumen ajustado
    }

    private void PlayEnemyShootSound(float volume)
    {
        if (soundManager != null && soundManager.enemyShootSound != null)
        {
            soundManager.soundEffectSource.PlayOneShot(soundManager.enemyShootSound, volume);
        }
    }

    public IEnumerator UpdateWeaponStatus(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!canShoot && !isWeaponActive)
        {
            weapon.SetActive(false);
        }

        if (!canShoot && isWeaponActive)
        {
            weapon.SetActive(true);
        }
        else if (canShoot && isWeaponActive)
        {
            weapon.SetActive(true);
        }
    }
}
