using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCoin : MonoBehaviour
{
    float time = 0;
    int rotate = 0;
    // Update is called once per frame
    void Update()
    {

        if (Time.time - time > 0.1f)
        {
            time = Time.time;
            transform.Rotate(0, 0, rotate);
            rotate += 1;
        }
        
    }
}
