using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecordData
{
    public int score;
    public bool isHighScore;

    public RecordData(int score , bool isHighScore)
    {
        this.score = score;
        this.isHighScore = isHighScore;
    }
}
