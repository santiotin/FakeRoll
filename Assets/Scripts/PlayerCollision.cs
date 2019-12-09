using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    Material m_Material;
    public Rigidbody rb;
    public GameObject champi;
    bool jumping = false;
    bool big = false;
    float time;
    Vector3 speedUp = new Vector3(0f,200f,0f);

    public AudioSource jumpAudio;
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        champi = GameObject.Find("ChampiTile");
        time = 1000;
    }
    void Update() {
        if(transform.position.y > 1) jumping = false;
        if ((Time.time - time) > 3)
        {
            time = 1000;
            big = false;
            GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
            GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
            transform.localScale -= new Vector3(1, 1, 1);
        }

    }

    void OnCollisionEnter(Collision  collisionInfo)
    {
        if (collisionInfo.collider.name == "block_tile") {//tag obstacle per qualsevol obj. amb aquest tag
            //you die
            movement.enabled = false;
        }
        if (collisionInfo.collider.name == "jump_tile" && !jumping) {
            //rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(0, 900, 0);
            jumping = true;
            jumpAudio.Play();
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

    }

    void OnTriggerEnter(Collider collider) {
        if(collider.name == "empty_tile") {
            rb.AddForce(0,-1000,0);
            jumping = false;
        }
        if(collider.name == "die_tile") {
            rb.AddForce(0,-1000,0);
            jumping = false;
            if (!big) big = true;
            else big = false;
            if (big)
            {
                time = Time.time;
            }
            else time = 1000;
            Destroy(champi); //No se destruye bien, aplicar animaciones
            transform.localScale += new Vector3(1, 1, 1);
        }
        if (collider.tag == "Champi")
        {
            // rb.AddForce(0,-1000,0);
            jumping = false;
            if (!big) big = true;
            else big = false;
            if (big)
            {
                time = Time.time;
            }
            else time = 1000;
            Destroy(collider); //champi
            GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
            GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
            transform.localScale += new Vector3(1, 1, 1);

        }
        if (collider.tag == "Star")
        {
            m_Material.color = Color.yellow;
            Destroy(collider);
        }
    }
   
}