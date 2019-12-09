using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0;
    float move = 0.02f;
    float test;
    bool up = true;
    // Update is called once per frame
    void Start()
    {
        transform.Rotate(-90, 0, 0);
        //transform.position += new Vector3(transform.position.x-3.4f, transform.position.y+5.56f, transform.position.z-0.4f);// 8.6 -5.06 8.6
    }
    void Update()
    {

        if (Time.time - time > 0.05f)
        {
            test = Time.time - time;
            //Debug.Log("La posició de la estrella és : " + transform.position.y);
            if (transform.position.y < 0.7 && up) transform.Translate(0, 0, move);
            else if (transform.position.y >= 0.7) up = false;
            if (!up && transform.position.y > 0.3) transform.Translate(0, 0, -move);
            else if (transform.position.y <= 0.3) up = true;
            time = Time.time;
            // se puede hacer mas bonito añadiendo limites de altura i haciendo un movimiento continuo ( cambiar tan bruscamente la pos )
        }

    }
}
