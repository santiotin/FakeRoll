using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    Vector3 speedForward = new Vector3(0,0,10f);
    Vector3 speedRight = new Vector3(5f,0,0f);
    Vector3 speedLeft = new Vector3(-5f,0,0f);

    Vector3 rotationX = new Vector3(720.0f, 0.0f, 0.0f);
    
    void Update()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //transform.position += speedForward * Time.deltaTime;
        transform.Translate(speedForward* Time.deltaTime, Space.World);
        transform.Rotate( rotationX * Time.deltaTime, Space.Self);
        var mousePos = Input.mousePosition;
        if ( Input.GetKey("d") || (mousePos.x > 455 && mousePos.x < 820 && mousePos.y > 0 && mousePos.y <= 420) ) //405
        {
            //rb.AddForce(30, 0, 0);
            //transform.position += speedForward * Time.deltaTime;
            transform.Translate(speedRight * Time.deltaTime, Space.World);
            
        }
        if (Input.GetKey("a") || (mousePos.x > 0 && mousePos.x <= 355 && mousePos.y > 0 && mousePos.y <= 420))
        {
            //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            transform.Translate(speedLeft * Time.deltaTime, Space.World);
        }
    }
}