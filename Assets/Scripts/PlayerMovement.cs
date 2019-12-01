using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    Vector3 speedForward = new Vector3(0,0,5f);
    Vector3 speedRight = new Vector3(5f,0,0f);
    Vector3 speedLeft = new Vector3(-5f,0,0f);

    Vector3 rotationX = new Vector3(720.0f, 0.0f, 0.0f);

    void Update()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //transform.position += speedForward * Time.deltaTime;
        transform.Translate(speedForward* Time.deltaTime, Space.World);
        transform.Rotate( rotationX * Time.deltaTime, Space.Self);

        if ( Input.GetKey("d") )
        {
            //rb.AddForce(30, 0, 0);
            //transform.position += speedForward * Time.deltaTime;
            transform.Translate(speedRight * Time.deltaTime, Space.World);
            
        }
        if (Input.GetKey("a") )
        {
            //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            transform.Translate(speedLeft * Time.deltaTime, Space.World);
        }
    }
}