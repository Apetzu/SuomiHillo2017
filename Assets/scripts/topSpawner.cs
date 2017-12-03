using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topSpawner : MonoBehaviour 
{
	GameObject[] spawnPoints;
	public int spawnPointCount = 5;
    public float b_randMinTime = 1;
    public float b_randMaxTime = 3;
    public float f_randMinTime = 10;
    public float f_randMaxTime = 20;
    public float t_randMinTime = 10;
    public float t_randMaxTime = 20;
    public GameObject bomber;
    public GameObject fighter;
    public GameObject tank;
	public float sideScreenBorder = 4;
    public float topScreenBorder = 4;
	public float spawnTopScreenBorder = 1.5f;
	public float spawnBottomScreenBorder = 2;

    float lastTime = 0;
    float randomTime = 0;
    float lastTime2 = 0;
    float randomTime2 = 0;
    float lastTime3 = 0;
    float randomTime3 = 0;
	Vector2 screenBottomLeft;
	Vector2 screenRightTop;

	void Start () 
    {
		screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
		screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));

		// creating spawnpoints
		spawnPoints = new GameObject[spawnPointCount];

		for (int i = 0; i < spawnPointCount; i++)
        {
			spawnPoints[i] = new GameObject("Spawnpoint" + i);
			spawnPoints[i].transform.SetParent (transform);
        }

		// scaling trigger and spawnpoints with screen size
        float spawnPointDelta = ((screenRightTop.y - spawnTopScreenBorder) - (screenBottomLeft.y + spawnBottomScreenBorder)) / (spawnPoints.Length - 1);

		for (int i = 0; i < spawnPoints.Length; i++)
		{
            spawnPoints [i].transform.position = new Vector2(screenRightTop.x + sideScreenBorder, (screenRightTop.y - spawnTopScreenBorder) - spawnPointDelta * i);
		}

        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

        colliders[0].size = new Vector2(1, (screenRightTop.y + topScreenBorder) * 2);
        colliders[0].offset = new Vector2(screenBottomLeft.x - sideScreenBorder, 0);
        colliders[1].size = new Vector2(screenRightTop.x * 2, 1);
        colliders[1].offset = new Vector2(0, screenRightTop.y + topScreenBorder);
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
            int randNum = Random.Range(1, spawnPoints.Length);
			Instantiate(fighter, spawnPoints[randNum].transform.position, spawnPoints[randNum].transform.rotation);

            lastTime2 = 0;
            randomTime2 = Random.Range(f_randMinTime, f_randMaxTime);
        }
        else
        {
            lastTime2 += Time.deltaTime;
        }

        if (lastTime3 >= randomTime3)
        {
            int randNum = Random.Range(1, spawnPoints.Length - 1);
            Instantiate(tank, spawnPoints[randNum].transform.position, spawnPoints[randNum].transform.rotation);

            lastTime3 = 0;
            randomTime3 = Random.Range(t_randMinTime, t_randMaxTime);
        }
        else
        {
            lastTime3 += Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
		if (obj.tag != "Player" && obj.tag != "BG")
			Destroy(obj.gameObject);
    }
}
