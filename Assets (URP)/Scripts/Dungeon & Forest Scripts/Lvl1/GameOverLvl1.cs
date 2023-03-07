using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLvl1 : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        GameObject _playerlvl1 = GameObject.Find("FPS Player Low Poly");
        _playerlvl1.GetComponent<PlayerControllerLvL1>().enabled = false;
    }

    public void ClickOnRestart()
    {
        SceneManager.LoadScene("Dungeon Scene Lvl1");
        Time.timeScale = 1;
        GameObject _playerlvl1 = GameObject.Find("FPS Player Low Poly");
        _playerlvl1.GetComponent<PlayerControllerLvL1>().enabled = true;
    }

    public void ClickOnQuit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}