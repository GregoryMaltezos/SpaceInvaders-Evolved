using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    
    public Transform firePoint;
   
    public GameObject bulletPrefab;
    


    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //Shoots by pressing the "Spacebar"
        {
            Shoot();
        }
    }
 
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //spawns bullet

    }                   
            
}
