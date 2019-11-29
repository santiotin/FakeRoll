using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 25f;

    public float downForce = 30f;

    public float sidewaysForce = 30f;



    // Start is called before the first frame update
   /* void Start()
    {
        rb.AddForce(0, 200, 10);
    }*/

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, forwardForce);

        if ( Input.GetKey("d") )
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a") )
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
