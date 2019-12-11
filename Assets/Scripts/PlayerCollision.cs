using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    Material m_Material;
    public Rigidbody rb;

    bool jumping = false;
    bool big = false;
    bool starEffect = false;

    float timeBig, timeStar;

    Vector3 speedUp = new Vector3(0f,200f,0f);


    public AudioSource coinAudio;
    public AudioSource starAudio;
    public AudioSource champiAudio;

    public Text coins;

    int numCoins = 0;


    public AudioSource jumpAudio;
    public AudioSource spikeAudio;
    public AudioSource powerAudio;

    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        timeBig = 1000;
        timeStar = 1000;
    }
    void Update() {
        if(transform.position.y > 1) jumping = false;
        if ((Time.time - timeBig) > 7)
        {
            timeBig = 1000;
            big = false;
            //GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
            //GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
            GetComponent<Rigidbody>().mass = 1;
            transform.localScale -= new Vector3(1, 1, 1);
        }
        if ((Time.time - timeStar) > 7)
        {
            timeStar = 1000;
            starEffect = false;
            GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
            GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
            m_Material.color = Color.white;
            powerAudio.Stop();
        }

        coins.text = numCoins.ToString();

    }

    void OnCollisionEnter(Collision  collisionInfo)
    {
        if (collisionInfo.collider.name == "block_tile" || collisionInfo.collider.name == "multiple_tile") {//tag obstacle per qualsevol obj. amb aquest tag
            //you die
            if(!big) movement.enabled = false;
        }
        if (collisionInfo.collider.name == "jump_tile" && !jumping) {
            //rb.constraints = RigidbodyConstraints.None;
            if(!big)rb.AddForce(0, 900, 0);
            else rb.AddForce(0, 900000, 0);
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
        }
        if (collider.tag == "Champi")
        {
            jumping = false;
            if (!big) big = true;
            else big = false;
            if (big)
            {
                timeBig = Time.time;
            }
            else timeBig = 1000;
            Destroy(collider); //champi collider.gameObject.SetActive(false);
            //GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
            //GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
            GetComponent<Rigidbody>().mass = 1000;
            champiAudio.Play();

            transform.localScale += new Vector3(1, 1, 1);

        }
        if (collider.tag == "Star")
        {
            jumping = false;
            if (!starEffect) starEffect = true;
            else starEffect = false;
            if (starEffect)
            {
                timeStar = Time.time;
            }
            else timeStar = 1000;
            collider.gameObject.SetActive(false);
            GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
            GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
            starAudio.Play();
            m_Material.color = Color.yellow;

            powerAudio.Play();
            
            Destroy(collider);
            numCoins++;
            
        }
        if (collider.tag == "Coin")
        {
            jumping = false;
            coinAudio.Play();
            collider.gameObject.SetActive(false);
        }
        if (collider.tag == "Spike")
        {
            jumping = false;
            spikeAudio.Play();
            collider.gameObject.SetActive(false);

        }
    }

    public bool isBig() {
        return big;
    }
   
}