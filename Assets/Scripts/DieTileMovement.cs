using UnityEngine;
using System;
using System.Collections;

public class DieTileMovement : MonoBehaviour
{
    private float range = 10.0f;
    private Transform player;
    public Rigidbody rb;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Distance() < 10) rb.useGravity = true;
    }

    private float Distance()
    {
        return Vector3.Distance(transform.position, player.position);
    }
}