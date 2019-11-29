using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rb;

    public int jumpForce = 500;

    void OnCollisionEnter(Collision  collisionInfo)
    {
        if (collisionInfo.collider.name == "block_tile") {//tag obstacle per qualsevol obj. amb aquest tag
            //you die
            movement.enabled = false;
        }
        if (collisionInfo.collider.name == "jump_tile") {
            Debug.Log("JUMP");
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(0, jumpForce, 0);
        }
        if (collisionInfo.collider.name == "ground_tile")
        {
            Debug.Log("down");
            rb.constraints &= RigidbodyConstraints.FreezePositionY;
            
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }
   
}
