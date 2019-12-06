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
        transform.Rotate(0, 0, 0);
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        transform.position += new Vector3(transform.position.x - 6.4f, transform.position.y + 5.7f, transform.position.z - 0.4f); //11.6 -5.2 17.6
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
