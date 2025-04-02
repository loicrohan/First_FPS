using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SingletonBGM.instance.printMessage(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
