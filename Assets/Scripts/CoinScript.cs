using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    Vector3 rotationY = new Vector3(0, 0 , 180.0f);
    Vector3 speed = new Vector3(0,10f,0);

    bool cached = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate( rotationY * Time.deltaTime, Space.Self);

        if(cached) {
            transform.Translate(speed* Time.deltaTime, Space.World);
        }

        if(transform.position.y > 10) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.name == "Player") {
            cached = true;
        }

    }
}
