using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    public AudioSource ggAudio;

    public GameObject background;

    bool done = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z >= 630 && !done) {
            Debug.Log("ENTREM DINS GG");
            done = true;
            ggAudio.Play();
            background.SetActive(true);
            
        }

        if(player.position.z >= 680) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
