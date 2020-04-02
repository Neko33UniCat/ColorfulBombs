using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringScript : MonoBehaviour
{
    public float Score;
    public float time;
    public bool isMoving;
    public float LastScore;
    public float TimeScore;
    public float BonusScore;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            time += Time.deltaTime;
        }
    }
    public void OutputLastScore()
    {
        //Score += (int)(Score / 10);
        //TimeScore = 36000 / time;
        //LastScore = Score + TimeScore;
        if (Score < 1000)//0~0
        {
            BonusScore = 0f;
        }
        else if (Score < 2000)//0.025~0.05
        {
            BonusScore = 50f;
        }
        else if (Score < 3000f)//0.067~0.1
        {
            BonusScore = 200f;
        }
        else if (Score < 4000f)//0.1~0.13
        {
            BonusScore = 400f;
        }
        else if (Score < 5000f)//0.13~0.1625
        {
            BonusScore = 650f;
        }
        else if (Score < 6000f)
        {
            BonusScore = 1000f;//0.17~0.20
        }
        else if(Score < 7000f)//0.20~0.23
        {
            BonusScore = 1400f;
        }
        else if(Score<8000f)//0.23~0.27
        {
            BonusScore = 1900f;
        }
        else if(Score < 8400)
        {
            BonusScore = 2400f;
        }
        else
        {
            BonusScore = 5000f;
        }

        //TimeScore = 36000 / time;
        TimeScore = Mathf.Round(36000f / time * 100f) / 100f;
    }
}
