using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGodMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown("space") ){
            GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
            GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
        }
    }
}
