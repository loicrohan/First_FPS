using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBox3 : MonoBehaviour
{
    public void OpenChest()
    {
        GetComponent<Animator>().Play("Open");
        Invoke("TakeTreasure", 5f);
    }

    public void TakeTreasure()
    {
        GameObject sc = GameObject.Find("Chest Box Canvas");
        sc.GetComponent<TreasureCounter>().UpdateScore();
        GetComponentInChildren<SphereCollider>().enabled = false;
    }
}
