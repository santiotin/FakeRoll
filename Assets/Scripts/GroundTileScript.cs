using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileScript : MonoBehaviour

{

    public Material touched;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInside()) gameObject.GetComponent<Renderer>().material = touched;
    }

    bool isInside(){
        Vector3 bounds = GetComponent<Renderer>().bounds.size;

        if(transform.position.x > player.position.x && transform.position.x - 1.5 < player.position.x) {
            if(player.position.z >= transform.position.z - 1.1 && transform.position.z - 0.5f > player.position.z) {
                return true;
            }
            else return false;
        }else return false;
    }
}
