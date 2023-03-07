using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureCounter : MonoBehaviour
{
    public Text _treasure;
    int currentTreasure;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int Treasure = 1)
    {
        currentTreasure += Treasure;
        _treasure.text = currentTreasure.ToString();
    }

}