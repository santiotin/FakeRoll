using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    bool mouse = false;

    bool started;
    Vector3 speedForward = new Vector3(0,0,10f);
    Vector3 speedRight = new Vector3(5f,0,0f);
    Vector3 speedLeft = new Vector3(-5f,0,0f);

    Vector3 rotationX = new Vector3(720.0f, 0.0f, 0.0f);

    Vector3 speedStop = new Vector3(0,0,0);

    Vector3 speedReduced = new Vector3(0,0,5f);

    Vector3 speed;

    void start() {
        speed = speedStop;
        started = false;
    }

    void Update()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //transform.position += speedForward * Time.deltaTime;
        transform.Translate(speed* Time.deltaTime, Space.World);
        if(started)transform.Rotate( rotationX * Time.deltaTime, Space.Self);
        var mousePos = Input.mousePosition;
        if (Input.GetKey("m") && mouse) mouse = false;
        else if (Input.GetKey("m") && !mouse) mouse = true;
        if (mouse)
        {
            if (mousePos.x > 455 && mousePos.x < 820 && mousePos.y > 0 && mousePos.y <= 420) transform.Translate(speedRight * Time.deltaTime, Space.World);//405
            else if (mousePos.x > 0 && mousePos.x <= 355 && mousePos.y > 0 && mousePos.y <= 420) transform.Translate(speedLeft * Time.deltaTime, Space.World);
        }
        else{
            if (Input.GetKey("d") && started)
            {
                if(GetComponent<PlayerCollision>().isStar() || GetComponent<PlayerCollision>().isBig()) rb.AddForce(80000, 0, 0);
                else rb.AddForce(80, 0, 0);
                //transform.Translate(speedRight * Time.deltaTime, Space.World);

            }
            if (Input.GetKey("a") && started)
            {
                if(GetComponent<PlayerCollision>().isStar() || GetComponent<PlayerCollision>().isBig()) rb.AddForce(-80000, 0, 0);
                else rb.AddForce(-80, 0, 0);
                //transform.Translate(speedLeft * Time.deltaTime, Space.World);
            }
        }
       
    }

    public void startGame() {
        speed = speedForward;
        started = true;

    }

    public void reduceVel() {
        speed = speedReduced;
    }

    public void incrementVel() {
        speed = speedForward;
    }
}