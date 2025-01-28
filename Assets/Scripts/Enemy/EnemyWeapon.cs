using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public GameObject projectile;
    public Transform firePoint;
    private float ShotDelay;
    public float StartShotDelay;


    private void Start()
    { 
        ShotDelay = StartShotDelay;
    }


    private void Update()  //Spawns bullet on the firepoint specified with delay
    {
        if (ShotDelay <= 0)
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            ShotDelay = StartShotDelay;
        }
        else
        {
            ShotDelay -= Time.deltaTime;
        }
    }
}
