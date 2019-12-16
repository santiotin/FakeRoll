using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGodMode : MonoBehaviour
{
    public GameObject godModeText;

    bool god = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown("space") ){
            god = !god;
            GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
            GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
        }

        if(god) godModeText.SetActive(true);
        else godModeText.SetActive(false);
    }
}
