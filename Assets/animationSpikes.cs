using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationSpikes : MonoBehaviour
{
    private Transform player;
    public float range = 20.0f;
    float time = 0;
    float move = 0.02f;
    bool pos = false;
    public AudioSource spikeAudio;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Distance() < range)
        {
            if (Time.time - time > 0.005f && !pos)
            {
                if (transform.position.y < -0.6f && !pos) transform.Translate(0, move, 0);
                else
                {
                    pos = true;
                    spikeAudio.Play();
                }
                time = Time.time;
            }
  
        }
            
    }
    private float Distance()
    {
        return Vector3.Distance(transform.position, player.position);
    }
}
