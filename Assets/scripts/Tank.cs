﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour 
{
    public Rigidbody2D hull;

    public float rotationSpeed = 1f;
    public float movementSpeed = 0.2f;
    public float fireRate = 0.1f;
    public GameObject tankProjectile;
	public float lenght = 0.5f;
    public float minRanPauseLenght = 1;
    public float maxRanPauseLenght = 1;
    public float minRanStartLenght = 2;
	public float maxRanStartLenght = 2;

    double lastTime = 0;
	double lastTime2 = 0;
	bool shooting = false;
    float pauseLenght;

	void Start () 
    {
        hull = GetComponent<Rigidbody2D>();

        lastTime2 = Random.Range(minRanStartLenght, maxRanStartLenght);
        pauseLenght = Random.Range(minRanPauseLenght, maxRanPauseLenght);
	}
	
	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.World);
        transform.Translate(Vector2.left * movementSpeed, Space.World);

		if (lastTime2 >= pauseLenght)
		{
			shooting = true;

			if (lastTime2 >= lenght + pauseLenght)
			{
				shooting = false;
				lastTime2 = 0;
			}
		}

        lastTime2 += Time.deltaTime;

		if (shooting)
		{
			if (lastTime >= fireRate)
			{
                GameObject shell = Instantiate(tankProjectile, transform.position + tankProjectile.transform.position, transform.rotation);
                Destroy(shell, 5);
				lastTime = 0;
			}
			else
			{
				lastTime += Time.deltaTime;
			}
		}
	}
}
