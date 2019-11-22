
using UnityEngine;

public class collisionJump : MonoBehaviour
{
    public Rigidbody rb;
    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.gameObject.name == "Player")
        {
            rb.AddRelativeForce(0, 200, 0);
        }
    }
}
