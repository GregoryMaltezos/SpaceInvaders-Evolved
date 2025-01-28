using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 2.0f;
    private Transform player;
    private Transform bulletTransform;
    private Vector2 target;
    private Vector3 playerPosition;
    private Vector3 direction;
    public GameObject impactEffect;
    void Start()
    {
        //Finds player's location

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y - 4);

        playerPosition = player.position;
        bulletTransform = GetComponent<Transform>();
        direction = (playerPosition - bulletTransform.position).normalized;
    }

   
    void Update()
    {
        //shoots bullet where the player is standing

        bulletTransform.position += direction * speed * Time.deltaTime;
        Destroy(gameObject, 12.0f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); 
        GameObject hit = Instantiate(impactEffect, transform.position, transform.rotation); //Spawns impact effect
        Destroy(hit, 0.4f); //Destroys impact effect
    }

}
