using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
  void OnCollisionEnter(Collision  collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") {//tag obstacle per qualsevol obj. amb aquest tag
            //you die
            movement.enabled = false;
        }
    }
   
}
