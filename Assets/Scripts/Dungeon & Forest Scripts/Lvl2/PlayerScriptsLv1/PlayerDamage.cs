using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float playerDamageAmount;
    public bool playerInRange = false;
    public DateTime nextDamage;
    public float damageAfterTime;
    public GameObject playerObj;

    // Awake is called before the first frame update
    void Awake()
    {
        nextDamage= DateTime.Now;   
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (playerInRange == true)
        {
            DamagePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           if(other.gameObject.GetComponent<PlayerHealthBar>().playerDied == false)
            {
                playerObj = other.gameObject;
                playerInRange = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public void DamagePlayer()  
    {
        if (nextDamage <=DateTime.Now)
        {
            playerObj.GetComponent<PlayerHealthBar>().AddDamage(playerDamageAmount);
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
        }
    }

}
