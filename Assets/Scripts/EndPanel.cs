using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    public GameObject background;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z >= 600) {
            background.SetActive(true);
        }

        if(player.position.z >= 630) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
