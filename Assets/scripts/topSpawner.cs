using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topSpawner : MonoBehaviour {

    public GameObject[] spawnPoints;
    public float randomMin = 1;
    public float randomMax = 3;

    float lastTime = 0;

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
        //int randomNum = Random.Range(0, spawnPoints.Length - 1);


	}
}
