using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBullet : MonoBehaviour
{

    public float speed = 2;

    private Transform bulletTransform;
    private Vector3 direction;

    public GameObject impactEffect;


    void Start()
    {
        bulletTransform = GetComponent<Transform>();
        direction = transform.localRotation * Vector3.down;
    }

  
    void Update()
    {
        bulletTransform.position += direction * speed * Time.deltaTime; //Moves enemy projectile downwards
        Destroy(gameObject, 4);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject hit = Instantiate(impactEffect, transform.position, transform.rotation); //Spawns impact effect
        Destroy(hit, 0.4f); //Destroys impact effect
    }
}
