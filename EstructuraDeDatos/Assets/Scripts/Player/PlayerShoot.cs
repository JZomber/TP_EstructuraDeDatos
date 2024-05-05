using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootingOrig;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            var rotation = transform.rotation;
            rotation *=  Quaternion.Euler(0, 0, -90);
            Instantiate(bulletPrefab, shootingOrig.position, rotation);
        }
    }
}
