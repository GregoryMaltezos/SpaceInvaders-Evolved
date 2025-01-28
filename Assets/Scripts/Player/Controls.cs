using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//testasdd
public class Controls : MonoBehaviour
{
    [SerializeField] private float speed = 300;
    private float HorizontalBorder = 11.0f;
    private float VerticalBorder = 6.0f;
    private Vector3 playerMovement;
    private Renderer myrenderer;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        //Allows player to move and sets the boundaries of the game

        playerMovement = new Vector3(Time.fixedDeltaTime * Input.GetAxisRaw("Horizontal") * speed, Time.fixedDeltaTime * Input.GetAxisRaw("Vertical") * speed, 0);
        Vector3 Difference = playerMovement * Time.fixedDeltaTime * 8;
        transform.position += Difference;
        playerMovement -= -Difference;

        if (transform.position.x < -HorizontalBorder)
            transform.position = new Vector3(-HorizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.x > HorizontalBorder)
            transform.position = new Vector3(HorizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.y < -VerticalBorder)
            transform.position = new Vector3(transform.position.x, -VerticalBorder, transform.position.z);
        if (transform.position.y > VerticalBorder)
            transform.position = new Vector3(transform.position.x, VerticalBorder, transform.position.z);

    }


    //When player is hit or collides with something, the player model flashes
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        sr.enabled = false;
        StartCoroutine(ExecuteAfterTime(0.2f));
        sr.enabled = false;
        StartCoroutine(ExecuteAfterTime(0.2f));
        sr.enabled = false;
        StartCoroutine(ExecuteAfterTime(0.2f));
        sr.enabled = false;
        StartCoroutine(ExecuteAfterTime(0.2f));

        GameManager.instance.UpdateLives(1);

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        sr.enabled = true;
        
    }
    void ResetMaterial()
    {
        sr.enabled = true;
    }


}