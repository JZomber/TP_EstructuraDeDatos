using System;
using System.Collections;
using System.Collections.Generic;
using UI.PowerUps;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    private TDA_Queue tdaQueue;
    // Start is called before the first frame update
    void Start()
    {
        tdaQueue = FindObjectOfType<TDA_Queue>(); // Busca el script TDA_Queue
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tdaQueue.RemovePowerUp();
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
