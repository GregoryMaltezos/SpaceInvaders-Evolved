using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //detects bullet collision with enemy and damages them
      Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.DamageTaken(1);
        }

        GameObject hit = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(hit, 0.4f); 

        
        Destroy(gameObject);
    }
}
