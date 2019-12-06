﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallMovement : MonoBehaviour
{
    bool moveRight;
    int rotate = 0;
    Vector3 speedRight = new Vector3(3f, 0, 0f);
    Vector3 speedLeft = new Vector3(-3f, 0, 0f);
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale += new Vector3(0.8, 0.8, 0.8);
        transform.position += new Vector3(transform.position.x-3.3f, transform.position.y + 8, transform.position.z);
        if (transform.position.x < 2.25) moveRight = true;
        else moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight && transform.position.x < 6)
        {
            rotate += 5;
            transform.Translate(speedRight * Time.deltaTime, Space.World);
            transform.Rotate(0, 0, rotate);
        }
        else
        {
            rotate -= 5;
            transform.Rotate(0, 0, rotate);
            moveRight = false;
            transform.Translate(speedLeft * Time.deltaTime, Space.World);
        }
        if (!moveRight && transform.position.x > -1.5)
        {
            rotate -= 5;
            transform.Translate(speedLeft * Time.deltaTime, Space.World);
            transform.Rotate(0, 0, rotate);
        }
        else
        {
            rotate += 5;
            transform.Rotate(0, 0, rotate);
            moveRight = true;
            transform.Translate(speedRight * Time.deltaTime, Space.World);
        }
    }
}