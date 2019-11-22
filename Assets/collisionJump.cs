
using UnityEngine;

public class collisionJump : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        
        if (collisionInfo.gameObject.name == "Player") {
            collisionInfo.gameObject.GetComponent<Rigidbody>().AddForce(0, 200, 0);
        }
    }
}
