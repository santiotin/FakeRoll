using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    public GameObject mainMenu;

    public GameObject startPanel;

    public GameObject endPanel;

    public GameObject hudPanel;

    public GameObject deadPanel;

    public AudioSource backgroundAudio;

    public AudioSource ggAudio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        mainMenu.SetActive(false);
        startPanel.SetActive(true);
        hudPanel.SetActive(true);
        player.GetComponent<PlayerMovement>().startGame();
    }

    public void hideStartPanel() {
        startPanel.SetActive(false);
    }

    public void showEndPanel() {
        endPanel.SetActive(true);
        backgroundAudio.Stop();
        ggAudio.Play();
        StartCoroutine(changeScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void manageDeath() {
        backgroundAudio.Stop();
        deadPanel.SetActive(true);
        StartCoroutine(changeScene(0));

    }

    IEnumerator changeScene(int sceneNum) {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneNum);
    }
}
