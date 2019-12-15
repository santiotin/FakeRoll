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

    public GameObject startMenu;

    public GameObject creditsMenu;

    public AudioSource backgroundAudio;

    public AudioSource ggAudio;

    bool started = false;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0) startGame();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("1") && !started ) {
            startGame();
        }
        if (Input.GetKey("2") && !started ) {
            showCreditsMenu();
        }
        if (Input.GetKey("3") && !started ) {
            QuitGame();
        }
        if (Input.GetKey("0") && !started ) {
            back();
        }
        if (Input.GetKey(KeyCode.F1)) {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.F2)) {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.F3)) {
            SceneManager.LoadScene(2);
        }
    }

    public void startGame() {
        started = true;
        mainMenu.SetActive(false);
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
        StartCoroutine(changeScene(0));

    }

    IEnumerator changeScene(int sceneNum) {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneNum);
    }

    public void showCreditsMenu() {
        startMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void back() {
        startMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
