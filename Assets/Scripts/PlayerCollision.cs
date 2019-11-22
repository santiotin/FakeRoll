using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public PlayerMovement movement;
    public Rigidbody rb;

    void OnCollisionEnter(Collision  collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") {//tag obstacle per qualsevol obj. amb aquest tag
            //you die
            movement.enabled = false;
        }
       /* if (collisionInfo.collider.tag == "Obstacle") {
            collisionInfo.gameObject.GetComponent<Rigidbody>().AddForce(0, 200, 0);
        }*/
    }
   
}
