using UnityEngine;
using System;
using System.Collections;

public class CollisionChampi : MonoBehaviour
{
    private Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Player")
        {
            // rb.AddForce(0,-1000,0);
            Debug.Log("Colision CHAMPI");
            Destroy(this);
            player.transform.localScale += new Vector3(1, 1, 1);
        }
    }
}