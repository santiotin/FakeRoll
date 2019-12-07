using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    Vector3 rotationX = new Vector3(-720.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( rotationX * Time.deltaTime, Space.Self);
    }
}
