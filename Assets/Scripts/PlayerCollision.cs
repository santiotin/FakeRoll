using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Material starMat;
    public Material normalMat;
    public Rigidbody rb;

    bool jumping = false;
    bool big = false;
    bool star = false;

    float timeBig, timeStar;

    Vector3 speedUp = new Vector3(0f,200f,0f);

    public Text coins;
    int numCoins = 0;

    public AudioSource coinAudio;
    public AudioSource starAudio;
    public AudioSource champiAudio;
    public AudioSource jumpAudio;
    public AudioSource fastAudio;
    public AudioSource spikeAudio;
    public AudioSource powerAudio;
    public AudioSource backgroundAudio;

    void Start()
    {
        timeBig = 0;
        timeStar = 0;
    }
    void Update() {
        if(transform.position.y > 1) jumping = false;

        if (big && (Time.time - timeBig) > 7) activateBig(false);

        if (star && (Time.time - timeStar) > 7) activateStar(false);

        coins.text = numCoins.ToString();

    }

    void OnCollisionEnter(Collision  collisionInfo)
    {
        if (collisionInfo.collider.name == "block_tile" || collisionInfo.collider.name == "multiple_tile") {
            //tag obstacle per qualsevol obj. amb aquest tag
            //you die
            if(!star && !big) movement.enabled = false;
        }
        if (collisionInfo.collider.name == "jump_tile" && !jumping) {

            if(!star) {
                jumping = true;
                jumpAudio.Play();

                if(!big)rb.AddForce(0, 875, 0);
                else rb.AddForce(0, 875000, 0);
            }
            
        }
       if (collisionInfo.collider.name == "ground_tile")
        {
            //rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            jumping = false;
        }

        if (collisionInfo.collider.name == "fast_tile")
        {
            rb.AddForce(0,0,2000);
            fastAudio.Play();
            jumping = false;
        }

    }

    void OnTriggerEnter(Collider collider) {
        if(collider.name == "empty_tile") {
            jumping = false;
            if(!star) rb.AddForce(0,-1000,0);
            
        }
        if(collider.name == "die_tile") {
            jumping = false;
            if(!star) rb.AddForce(0,-1000,0);
            
        }
        if (collider.tag == "Champi" && !star)
        {
            jumping = false;
            if(!big)  {
                activateBig(true);
                Destroy(collider.gameObject);
            }
            else {
                reActivateBig();
                Destroy(collider.gameObject);
            }

        }
        if (collider.tag == "Star" && !big )
        {
            jumping = false;
            if(!star) {
                activateStar(true);
                Destroy(collider.gameObject);
            }
            else {
                reActivateStar();
                Destroy(collider.gameObject);
            }
        }
        if (collider.tag == "Coin")
        {
            jumping = false;
            coinAudio.Play();
            numCoins++;
        }
        if (collider.tag == "Spike")
        {
            jumping = false;
        }
    }

    public bool isBig() {
        return big;
    }

    public bool isStar() {
        return star;
    }

    void activateStar(bool activate) {
        if(activate) {
            star = true;
            timeStar = Time.time;

            GetComponent<Rigidbody>().mass = 1000;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            
            backgroundAudio.Pause();
            starAudio.Play();
            powerAudio.Play();

            StartCoroutine(changeToStarColor());

        } else {
            star = false;
            timeStar = 0;

            GetComponent<Rigidbody>().mass = 1;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            powerAudio.Stop();
            backgroundAudio.UnPause();

            StartCoroutine(changeToNormalColor());
        }
    }

    void reActivateStar() {
        timeStar = Time.time;
        starAudio.Play();
    }

    void activateBig(bool activate) {
        if(activate) {
            big = true;
            timeBig = Time.time;
            GetComponent<Rigidbody>().mass = 1000;
            champiAudio.Play();
            StartCoroutine(IncrementScale());

            
        }
        else {
            big = false;
            timeBig = 0;
            GetComponent<Rigidbody>().mass = 1;
            champiAudio.Play();
            StartCoroutine(ReduceScale());
        }
    }

    void reActivateBig() {
        timeBig = Time.time;
        champiAudio.Play();
    }

    IEnumerator IncrementScale()
    {
        GetComponent<PlayerMovement>().reduceVel();
        yield return new WaitForSeconds(0.2f);
        transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(0.2f);
        transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(0.2f);
        transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(0.2f);
        transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
        GetComponent<PlayerMovement>().incrementVel();
    }

    IEnumerator ReduceScale()
    {
        GetComponent<PlayerMovement>().reduceVel();
        yield return new WaitForSeconds(0.2f);
        transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(0.2f);
        transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(0.2f);
        transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        yield return new WaitForSeconds(0.2f);
        transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        GetComponent<PlayerMovement>().incrementVel();
    }

    IEnumerator changeToStarColor()
    {
        GetComponent<PlayerMovement>().reduceVel();
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = starMat;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = normalMat;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = starMat;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = normalMat;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = starMat;
        GetComponent<PlayerMovement>().incrementVel();
    }

    IEnumerator changeToNormalColor()
    {
        GetComponent<PlayerMovement>().reduceVel();
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = normalMat;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = starMat;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = normalMat;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = starMat;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = normalMat;
        GetComponent<PlayerMovement>().incrementVel();
    }
   
}