using UnityEngine;
using System;
using System.Collections;

public class DieTileMovement : MonoBehaviour
{
    public float range = 20.0f;
    private Transform player;
    public Rigidbody rb;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Distance() < range) rb.useGravity = true;
    }

    private float Distance()
    {
        return Vector3.Distance(transform.position, player.position);
    }
}