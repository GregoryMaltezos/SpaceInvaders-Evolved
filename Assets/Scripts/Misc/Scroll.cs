using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 4f;
    public Renderer Myrend;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0,Time.time * speed);
        Myrend.material.mainTextureOffset = offset;
    }
}
