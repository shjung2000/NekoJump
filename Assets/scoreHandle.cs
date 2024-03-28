using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreHandle : MonoBehaviour
{
    public int playerScore;
    public Text playerScoreText;

    

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    public void addScore()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }

    
}
