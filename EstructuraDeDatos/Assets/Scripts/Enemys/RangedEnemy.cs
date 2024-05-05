using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform shootingOrig;
    public GameObject bulletPrefab;

    private float coolDown;
    public float shootCoolDown;

    public GameObject weapon;
    public bool canShoot = true;
    
        
    // Start is called before the first frame update
    void Start()
    {
        coolDown = shootCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        
        if (coolDown <= 0f && canShoot)
        {
            var rotation = shootingOrig.rotation;
            rotation *=  Quaternion.Euler(0, 0, -90);
            Instantiate(bulletPrefab, shootingOrig.position, rotation);

            coolDown = shootCoolDown;
        }

        if (!canShoot)
        {
            weapon.GameObject().SetActive(false);
        }
    }
}
