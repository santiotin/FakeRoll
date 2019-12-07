using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    bool mouse = false;
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
        if (Input.GetKey("m") && mouse) mouse = false;
        else if (Input.GetKey("m") && !mouse) mouse = true;
        if (mouse)
        {
            if (mousePos.x > 455 && mousePos.x < 820 && mousePos.y > 0 && mousePos.y <= 420) transform.Translate(speedRight * Time.deltaTime, Space.World);//405
            else if (mousePos.x > 0 && mousePos.x <= 355 && mousePos.y > 0 && mousePos.y <= 420) transform.Translate(speedLeft * Time.deltaTime, Space.World);
        }
        else{
            if (Input.GetKey("d"))
            {
                //rb.AddForce(30, 0, 0);
                //transform.position += speedForward * Time.deltaTime;
                transform.Translate(speedRight * Time.deltaTime, Space.World);

            }
            if (Input.GetKey("a"))
            {
                //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                transform.Translate(speedLeft * Time.deltaTime, Space.World);
            }
        }
       
    }
}