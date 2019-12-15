using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float offset;

    public float desplY = 50;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0,0,player.position.z);
        //transform.position = player.position + offset;
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + offset);
    }

}
