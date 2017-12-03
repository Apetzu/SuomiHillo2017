using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreCounter : MonoBehaviour {

    bool canPress = false;

    public Text ScoreAmount;
    public float Score;
    public Text EndScore;

    bool playerKilled = false;

	void Start ()
    {
        Score = 0;
        setScore();
	}
	

	void FixedUpdate ()
    {
        if (playerKilled == false)
        {
            Score += Time.fixedDeltaTime;
            setScore();
        }
        else
        {
            if (Input.anyKeyDown && canPress)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}

    void setScore()
    {
        ScoreAmount.text = "Score: " + Mathf.RoundToInt(Score).ToString();
    }

    IEnumerator KeyWait()
    {
        yield return new WaitForSeconds(2);
        canPress = true;
    }

    public void AddScore(/*float scoreVar*/)
    {
        Score += 25;
    }

    public void GameOver()
    {
        playerKilled = true;
        StartCoroutine("KeyWait");
        ScoreAmount.enabled = false;
        EndScore.transform.parent.gameObject.SetActive(true);
        EndScore.text = "Your score was:  " + Mathf.RoundToInt(Score).ToString();
    }
}
