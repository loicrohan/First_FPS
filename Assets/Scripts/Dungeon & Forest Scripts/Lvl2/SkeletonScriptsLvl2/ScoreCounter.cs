using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text _scoreText;
    int currentScore;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int score = 1)
    {
        currentScore += score;
        _scoreText.text = currentScore.ToString();
    }
}
