using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject lvl1Instr,lvl2Instr,lvl1more;

    public void ClickStart()
    {
        SceneManager.LoadScene("Dungeon Scene Lvl1");
    }
    public void ClickInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ClickBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void clickQuit()
    {
        Application.Quit();
    }

    public void ClickNextInstruction()
    {
        lvl1Instr.SetActive(false);
        lvl2Instr.SetActive(true);
        lvl1more.SetActive(false);
    }

    public void ClickPrevInstruction()
    {
        lvl1Instr.SetActive(true);
        lvl2Instr.SetActive(false);
        lvl1more.SetActive(false);
    }

    public void ClickMorelvl1Instruction()
    {
        lvl1Instr.SetActive(false);
        lvl2Instr.SetActive(false);
        lvl1more.SetActive(true);
    }

    public void ClickPrevlvl1Instruction()
    {
        lvl1Instr.SetActive(true);
        lvl2Instr.SetActive(false);
        lvl1more.SetActive(false);
    }
}