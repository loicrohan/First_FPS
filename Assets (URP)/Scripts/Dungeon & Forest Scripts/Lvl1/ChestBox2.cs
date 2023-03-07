using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBox2 : MonoBehaviour
{
    public void OpenChest()
    {
        GetComponent<Animator>().Play("Open");
        Invoke("TakeSecondTreasure", 5f);
    }

    public void TakeSecondTreasure()
    {
        GameObject sc = GameObject.Find("Chest Box Canvas");
        sc.GetComponent<TreasureCounter>().UpdateScore();
        GetComponentInChildren<SphereCollider>().enabled = false;   
    }
}