using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject DroppedLives;
    [SerializeField] public int HP = 10;
    public static int points { get; set; }
    public GameObject deathEffect;


    private void Start()
    {
        points = HP * 100; 
    }

    public void DamageTaken(int damage)  //Reduces HP when hit by player. If HP reaches 0 enemy dies
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }
    }





    void Die()
    {
        
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        const float dropChance = 1f / 25f;  //Determines what the chance is for an enemy to drop extra lives

        if (Random.Range(0f, 1f) <= dropChance) // Makes enemies drop extra lives
        {
            Instantiate(DroppedLives, transform.position, Quaternion.identity);
        }
        ScoreManager.instance.AddPoint();  //Adds points to player's score based on enemy's HP
        Destroy(gameObject);
        
    }
}


