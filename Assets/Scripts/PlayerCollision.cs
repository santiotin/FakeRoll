using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public PlayerMovement movement;
    public Rigidbody rb;

    void OnCollisionEnter(Collision  collisionInfo)
    {
        if (collisionInfo.collider.name == "block_tile") {//tag obstacle per qualsevol obj. amb aquest tag
            //you die
            movement.enabled = false;
        }
        if (collisionInfo.collider.name == "jump_tile") {
            Debug.Log("JUMP");
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(0, 140, 0);
        }
       if (collisionInfo.collider.name == "ground_tile")
        {
            Debug.Log("down");
            rb.constraints &= RigidbodyConstraints.FreezePositionY;
            rb.AddForce(0, 0, 0);
        }
    }
   
}
