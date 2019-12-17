using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject mainMenu;

    public GameObject startMenu;

    public GameObject creditsMenu;

    public AudioSource backgroundAudio;

    public GameObject fadeBackground;

    public AudioSource btnPress;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("1")) {
            playGame();
        }
        if (Input.GetKey("2")) {
            showCreditsMenu();
        }
        if (Input.GetKey("3")) {
            quitGame();
        }
        if (Input.GetKey("0")) {
            back();
        }
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

    public void playGame() {
        backgroundAudio.Stop();
        btnPress.Play();
        fadeBackground.SetActive(true);
        StartCoroutine(changeScene(1));
    }

    public void showCreditsMenu() {
        btnPress.Play();
        startMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void back() {
        btnPress.Play();
        startMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void quitGame() {
        btnPress.Play();
        Debug.Log("Quit!");
        Application.Quit();
    }

    IEnumerator changeScene(int sceneNum) {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneNum);
    }
}
