using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationSpikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(transform.position.x + 1.1f, transform.position.y + 4.6f, transform.position.z - 3.4f);//2.6 -5.2 5.6
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
