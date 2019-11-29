using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float backwardForce = -300f;

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, backwardForce * Time.deltaTime);
    }
}
