using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public PlayerMovement movement;
    public Rigidbody rb;

    bool jumping = false;

    Vector3 speedUp = new Vector3(0f,200f,0f);

    void Update() {
        if(transform.position.y > 5) jumping = false;
    }

    void OnCollisionEnter(Collision  collisionInfo)
    {
        if (collisionInfo.collider.name == "block_tile") {//tag obstacle per qualsevol obj. amb aquest tag
            //you die
            movement.enabled = false;
        }
        if (collisionInfo.collider.name == "jump_tile" && !jumping) {
            //rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(0, 1200, 0);
            jumping = true;
            //gameObject.collider.enabled = true;
            //transform.Translate(speedUp * Time.deltaTime);
        }
       if (collisionInfo.collider.name == "ground_tile")
        {
            //rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            jumping = false;
        }
        if (collisionInfo.collider.name == "empty_tile")
        {
           // rb.AddForce(0,-1000,0);
            jumping = false;
        }
        if (collisionInfo.collider.name == "fast_tile")
        {
           
            rb.AddForce(0,0,2000);
            jumping = false;
        }
    }
   
}