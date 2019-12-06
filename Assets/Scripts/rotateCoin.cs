using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCoin : MonoBehaviour
{
    float time = 0;
    int rotate = 0;
    void Start()
    {
        transform.position += new Vector3(transform.position.x - 3.4f, transform.position.y + 5.7f, transform.position.z - 3.4f);//2.8 -2.6 5.6
        transform.Rotate(90, 0, 0);
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        
    }
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
