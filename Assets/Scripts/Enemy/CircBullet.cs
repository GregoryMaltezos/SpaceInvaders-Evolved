using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircBullet : MonoBehaviour
{
    
    public float speed = 2;
    private Transform bulletTransform;
    private Vector3 direction;
    private Vector2 velocity;
    public GameObject impactEffect;

    void Start()
    {
        bulletTransform = GetComponent<Transform>();
        direction = transform.localRotation * Vector3.right;
       
    }

    void Update() //Shoots bullet in a straight line based on its Firepoint's position and rotation
    {
        bulletTransform.position += direction * speed * Time.deltaTime;
        velocity = direction * speed;
        Destroy(gameObject, 12);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject hit = Instantiate(impactEffect, transform.position, transform.rotation); //Spawns impact effect
        Destroy(hit, 0.4f); //Destroys impact effect
    }

}
