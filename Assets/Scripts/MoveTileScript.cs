using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTileScript : MonoBehaviour
{
    bool moveRight;
    Vector3 speed = new Vector3(3f, 0, 0f);

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 2.25) moveRight = true;
        else moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight && transform.position.x < 6) transform.Translate(speed * Time.deltaTime, Space.World);
        else
        {
            moveRight = false;
            transform.Translate(-1.0f * speed * Time.deltaTime, Space.World);
        }
        if (!moveRight && transform.position.x > -1.5) transform.Translate( -1.0f * speed * Time.deltaTime, Space.World);
        else
        {
            moveRight = true;
            transform.Translate(speed * Time.deltaTime, Space.World);
        }
    }
}
