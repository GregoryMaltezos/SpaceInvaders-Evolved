using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    [SerializeField] public float interval = 2f; //Seconds between spawns
    private float timer = 0f;

    //Spawns desired enemy if more time has passed than what is specified on "interval" variable
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }

    }
}