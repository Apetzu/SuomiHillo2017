using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topSpawner : MonoBehaviour 
{

    public GameObject[] spawnPoints;
    public float b_randMinTime = 1;
    public float b_randMaxTime = 3;
    public float f_randMinTime = 10;
    public float f_randMaxTime = 20;
    public GameObject bomber;
    public GameObject fighter;

    float lastTime = 0;
    float randomTime = 0;
    float lastTime2 = 0;
    float randomTime2 = 0;

	void Start () 
    {
        spawnPoints = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i).gameObject;
        }
	}
	
	void Update () 
    {
        if (lastTime >= randomTime)
        {
            Instantiate(bomber, spawnPoints[0].transform.position, spawnPoints[0].transform.rotation);

            lastTime = 0;
            randomTime = Random.Range(b_randMinTime, b_randMaxTime);
        }
        else
        {
            lastTime += Time.deltaTime;
        }

        if (lastTime2 >= randomTime2)
        {
            int randNum = Random.Range(1, spawnPoints.Length - 1);
            Instantiate(fighter, spawnPoints[randNum].transform.position, spawnPoints[randNum].transform.rotation);

            lastTime2 = 0;
            randomTime2 = Random.Range(f_randMinTime, f_randMaxTime);
        }
        else
        {
            lastTime2 += Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        Destroy(obj.gameObject);
    }
}
