using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseLvl1 : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject plr = GameObject.Find("FPS Player Low Poly");
        plr.GetComponent<PlayerControllerLvL1>().enabled = false;
        GameObject cam = GameObject.Find("Camera");
        cam.GetComponent<CameraController>().enabled = false;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject plr = GameObject.Find("FPS Player Low Poly");
        plr.GetComponent<PlayerControllerLvL1>().enabled = true;
        GameObject cam = GameObject.Find("Camera");
        cam.GetComponent<CameraController>().enabled = true;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}