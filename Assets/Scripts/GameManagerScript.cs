using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    public GameObject startPanel;

    public GameObject endPanel;

    public GameObject hudPanel;

    public GameObject deadPanel;

    public AudioSource backgroundAudio;

    public AudioSource ggAudio;

    void Start()
    {
        startGame();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.F1)) {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.F2)) {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKey(KeyCode.F3)) {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKey(KeyCode.F4)) {
            SceneManager.LoadScene(0);
        }
    }

    public void startGame() {
        startPanel.SetActive(true);
        hudPanel.SetActive(true);
        player.GetComponent<PlayerMovement>().startGame();
    }

    public void hideStartPanel() {
        startPanel.SetActive(false);
        player.GetComponent<PlayerMovement>().startRace();
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
        StartCoroutine(changeSceneDead(SceneManager.GetActiveScene().buildIndex));

    }

    IEnumerator changeScene(int sceneNum) {
        yield return new WaitForSeconds(5);
        if(sceneNum != 4) SceneManager.LoadScene(sceneNum);
        else SceneManager.LoadScene(0);
    }

    IEnumerator changeSceneDead(int sceneNum) {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneNum);
    }
}
