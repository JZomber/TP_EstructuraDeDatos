using System;
using System.Collections;
using System.Collections.Generic;
using PowerUps;
using UI.PowerUps;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    public GameObject shieldPrefab;
    private ShieldPowerUp shieldPowerUp;
    
    private TDA_Queue tdaQueue;
    private GameObject powerUp;

    private CapsuleCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        shieldPowerUp = shieldPrefab.GetComponent<ShieldPowerUp>();
        playerCollider = this.GameObject().GetComponent<CapsuleCollider2D>();
        tdaQueue = FindObjectOfType<TDA_Queue>(); // Busca el script TDA_Queue
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Input - SPACE
        {
            powerUp = tdaQueue.currentPowerUp; //Referencio al primer objeto de la TDA Cola

            if (powerUp.name == "Shield") // Si el objeto es el escudo
            {
                playerCollider.enabled = false;
                shieldPrefab.SetActive(true);
            }
            tdaQueue.RemovePowerUp(); //Quito el objeto del TDA Cola
        }

        if (shieldPowerUp.damageResist <= 0) //Si la resistencia del escudo termina
        {
            playerCollider.enabled = true;
            shieldPrefab.SetActive(false);
            shieldPowerUp.damageResist = 5;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp")) // Si el jugador colisiona con un enemigo y puede tomar daño
        {
            tdaQueue.AddPowerUp(other.GameObject());
        }
    }
}
