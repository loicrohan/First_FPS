using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour {

    //This script goes on the SpikeTrap prefab;

    public Animator spikeTrapAnim; //Animator for the SpikeTrap;

    // Use this for initialization
    void Awake()
    {
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
    }


    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        //wait 1 second;
        yield return new WaitForSeconds(1);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        //wait 1 second;
        yield return new WaitForSeconds(1);
        //Do it again;
        StartCoroutine(OpenCloseTrap());
    }
}