using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFirePoint : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    private float ShotDelay;
    public float StartShotDelay;


    private void Start()
    {
        ShotDelay = StartShotDelay;
    }


    private void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime); //rotates enemy 50 degrees per second around z axis

        if (ShotDelay <= 0) //Shoots bullet from 5 different FirePoints
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            Instantiate(projectile, firePoint1.position, firePoint1.rotation);
            Instantiate(projectile, firePoint2.position, firePoint2.rotation);
            Instantiate(projectile, firePoint3.position, firePoint3.rotation);
            Instantiate(projectile, firePoint4.position, firePoint4.rotation);

            ShotDelay = StartShotDelay;
        }
        else
        {
            ShotDelay -= Time.deltaTime;
        }
    }
}


