using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{

    private bool dirRight = true;
    public float speed = 1.0f;
    

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        if(transform.position.x >= -9.32)
        {
            dirRight = false;
        }

        if(transform.position.x <= -10.31921)
        {
            dirRight = true;
        }
    }
}
