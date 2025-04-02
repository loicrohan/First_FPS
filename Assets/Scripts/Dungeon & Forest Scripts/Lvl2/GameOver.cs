using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    [SerializeField]
    private Text currentScore;
    [SerializeField]
    private Text finalScore;

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true);
        finalScore.text = currentScore.text;
         currentScore.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClickOnRestart()
    {
        SceneManager.LoadScene("Dungeon Scene Lvl1");
        Time.timeScale = 1;
    }

    public void ClickOnQuit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}