using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0;
    float move = 0.0f;
    // Update is called once per frame
    void Update()
    {

        if (Time.time - time > 0.3f)
        {
            time = Time.time;
            transform.Translate(0, 0, move); // se puede hacer mas bonito añadiendo limites de altura i haciendo un movimiento continuo ( cambiar tan bruscamente la pos )
            move *= -1;
        }

    }
}
