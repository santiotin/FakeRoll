using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float range = 10f;

    bool created = false;
    public GameObject blockModel;
     private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Distance() < range && !created) createBlocksDiag();
    }

    private float Distance()
    {
        return Vector3.Distance(transform.position, player.position);
    }

    void createBlocksLeftRight() {
        created = true;
        //create piece
        Vector3 posL = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z + 0.2f);
        Vector3 posR = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z + 0.2f);
        Instantiate(blockModel, posL, transform.rotation);
        Instantiate(blockModel, posR, transform.rotation);
    
    }

    void createBlocksDiag() {
        created = true;
        //create piece
        Vector3 posL = new Vector3(transform.position.x - 3.0f, transform.position.y, transform.position.z + 0.2f);
        Vector3 posR = new Vector3(transform.position.x + 3.0f, transform.position.y, transform.position.z + 0.2f);
        Instantiate(blockModel, posL, transform.rotation);
        Instantiate(blockModel, posR, transform.rotation);
    
    }
}
