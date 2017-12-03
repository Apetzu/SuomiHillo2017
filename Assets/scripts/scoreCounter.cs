using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoreCounter : MonoBehaviour {


    public Text ScoreAmount;
    public float Score;
    

	void Start ()
    {
        Score = 0;
        setScore();
	}
	

	void FixedUpdate ()
    {
        Score += Time.fixedDeltaTime;
        setScore();
	}

    void setScore()
    {
        ScoreAmount.text = "Score: " + Mathf.RoundToInt(Score).ToString();
    }

    public void AddScore(/*float scoreVar*/)
    {
        Score += 25;
    }
}
