﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is integrations
public class PlayerDestroy : MonoBehaviour
{
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    public Material material;

    public GameObject gameManager;

    AudioSource explote;

    // Use this for initialization
    void Start() {

        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 3;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

        explote = gameManager.GetComponents<AudioSource>()[1];

    }

    // Update is called once per frame
    void Update() {
        
        if(transform.position.y < -0.5) explode();
        

    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.name == "block_tile" || other.gameObject.name == "multiple_tile") {
            if( !gameObject.GetComponent<PlayerCollision>().isStar() && 
                !gameObject.GetComponent<PlayerCollision>().isBig() )
                explode();
        }

        if (other.gameObject.name == "spike_ball" || other.gameObject.tag == "Spike") {
            if( !gameObject.GetComponent<PlayerCollision>().isStar())
                explode();
        }

    }

    void OnCollisionEnter(Collision  collisionInfo) {
        if(collisionInfo.gameObject.name == "cylinder_tile") {
            if( !gameObject.GetComponent<PlayerCollision>().isStar())
                explode();
        }
    }

    public void explode() {
        //make object disappear
        explote.Play();
        gameObject.SetActive(false);
        

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

        gameManager.GetComponent<GameManagerScript>().manageDeath();

    }

    void createPiece(int x, int y, int z) {

        //create piece
        GameObject piece;

        piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        piece.GetComponent<Renderer>().material = material;


        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);


        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }

    
}
