using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBox : MonoBehaviour
{
    [SerializeField] NextLvl _NextLvl;
    [SerializeField]
    private AudioClip _clip;

    public void OpenChest()
    {
        GetComponent<Animator>().Play("Open");
        Invoke("SpawnNxtLvl", 7f);
    }

    public void SpawnNxtLvl()
    {
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
        _NextLvl.WinScreen();
        Cursor.lockState = CursorLockMode.None;
    }
}