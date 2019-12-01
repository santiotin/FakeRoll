using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public PlayerMovement movement;
    public Rigidbody rb;
    private Transform champi;
    bool jumping = false;
    bool big = false;
    float time;
    Vector3 speedUp = new Vector3(0f,200f,0f);
    void Start()
    {
        champi = GameObject.FindGameObjectWithTag("Champi").transform;
        time = 1000;
    }
    void Update() {
        if(transform.position.y > 2) jumping = false;
        Debug.Log(Time.time);
        if ((Time.time - time) > 3)
        {
            time = 1000;
            big = false;
            transform.localScale -= new Vector3(1, 1, 1);
        }

    }

    void OnCollisionEnter(Collision  collisionInfo)
    {
        if (collisionInfo.collider.name == "block_tile") {//tag obstacle per qualsevol obj. amb aquest tag
            //you die
            Debug.Log("Colision BLOCK");
            movement.enabled = false;
        }
        if (collisionInfo.collider.name == "jump_tile" && !jumping) {
            //rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(0, 1300, 0);
            jumping = true;
            //gameObject.collider.enabled = true;
            //transform.Translate(speedUp * Time.deltaTime);
        }
       if (collisionInfo.collider.name == "ground_tile")
        {
            //rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            jumping = false;
        }

        if (collisionInfo.collider.name == "fast_tile")
        {
           
            rb.AddForce(0,0,2000);
            jumping = false;
        }
        if (collisionInfo.collider.name == "champi_tile")
        {
            // rb.AddForce(0,-1000,0);
            Debug.Log("Colision CHAMPI");
        }

    }

    void OnTriggerEnter(Collider collider) {
        if(collider.name == "empty_tile") {
            Debug.Log("emptyyyy");
            rb.AddForce(0,-1000,0);
            jumping = false;
        }
        if(collider.name == "die_tile") {
            Debug.Log("diee");
            rb.AddForce(0,-1000,0);
            jumping = false;
            if (!big) big = true;
            else big = false;
            if (big)
            {
                time = Time.time;
            }
            else time = 1000;
            Destroy(champi);
            transform.localScale += new Vector3(1, 1, 1);
            
        }
    }
   
}