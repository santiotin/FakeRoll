﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDestroy : MonoBehaviour
{

    public float cubeSize = 0.2f;
    public int cubesInRow = 4;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 100f;
    public float explosionRadius = 10f;
    public float explosionUpward = 2f;

    public AudioSource explodeAudio;
    // Start is called before the first frame update
    void Start()
    {
         //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 3;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            if( other.gameObject.GetComponent<PlayerCollision>().isStar()) 
                explode();
        }

    }

    public void explode() {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        explodeAudio.Play();
        
        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++) {
            for (int y = 0; y < cubesInRow; y++) {
                for (int z = 0; z < cubesInRow; z++) {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders) {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

        Destroy(gameObject, 0.5f);

    }

    void createPiece(int x, int y, int z) {

        //create piece
        GameObject piece;

        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //piece.GetComponent<MeshFilter>().sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
        piece.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;


        //set piece position and scale
        piece.transform.position = transform.position + new Vector3((cubeSize * x), (cubeSize * y), (cubeSize * z)) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize * 0.1f, cubeSize, cubeSize * 0.1f);


        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }
}
