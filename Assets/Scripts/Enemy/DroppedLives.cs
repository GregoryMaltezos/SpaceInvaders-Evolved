using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedLives : MonoBehaviour
{
    public float speed = 2;
    private Transform LivesTransform;
    private Vector3 direction;
   
    void Start()
    {
        LivesTransform = GetComponent<Transform>();
        direction = transform.localRotation * Vector3.down;
    }

   
    void Update()  //When Bonus lives spawn the move down and after 5 seconds they dissapear
    {
        LivesTransform.position += direction * speed * Time.deltaTime; 
        Destroy(gameObject, 5);
    }


    private void OnCollisionEnter2D(Collision2D collision) //When player picks up
    {
        GameManager.instance.UpdateLives(2); //Increases Player's Lives
        Destroy(gameObject);
    }
}
