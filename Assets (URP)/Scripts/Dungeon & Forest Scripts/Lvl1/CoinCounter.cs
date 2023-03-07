using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text _coins;
    public int currentCoins;

    public void UpdateScore(int Coins = 1)
    {
        currentCoins += Coins;
        _coins.text = currentCoins.ToString();

        if (currentCoins == 5)
        {
            GameObject WC = GameObject.Find("Wooden_Chest");
            WC.GetComponentInChildren<SphereCollider>().enabled = true;
        }
        else if (currentCoins == 10)
        {
            GameObject SilC = GameObject.Find("Silver_Chest");
            SilC.GetComponentInChildren<SphereCollider>().enabled = true;
        }
        else if (currentCoins == 15)
        {
            GameObject GC = GameObject.Find("Golden_Chest");
            GC.GetComponentInChildren<SphereCollider>().enabled = true;
        }
    }
}