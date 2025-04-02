using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    public GameObject NextLvlcanvas;

    public void WinScreen()
    {
        NextLvlcanvas.SetActive(true);
        Time.timeScale = 0;
        GameObject _playerlvl1 = GameObject.Find("FPS Player Low Poly");
        _playerlvl1.GetComponent<PlayerControllerLvL1>().enabled = false;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1;
        GameObject _playerlvl1 = GameObject.Find("FPS Player Low Poly");
        _playerlvl1.GetComponent<PlayerControllerLvL1>().enabled = true;
    }
}