using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public Rigidbody rb;
    private Transform player;
    public float backwardForce;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Distance() < 20) // cuando este a 20 del player se mueve
        {
            rb.useGravity = true;
            rb.AddForce(0, 0, backwardForce * Time.deltaTime);
        }

    }
    private float Distance()
    {
        return Vector3.Distance(transform.position, player.position);
    }
}
