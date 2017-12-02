using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeShooting : MonoBehaviour 
{
    public float movementSpeed = 0.2f;
    public float fireRate = 0.1f;
    public GameObject projectile;
	public float lenght = 0.5f;
    public float minRanPauseLenght = 1;
    public float maxRanPauseLenght = 1;
    public float minRanStartLenght = 2;
	public float maxRanStartLenght = 2;

    double lastTime = 0;
	double lastTime2 = 0;
	bool shooting = false;
    float pauseLenght;
    Vector2 screenBottomLeft;

	void Start () 
    {
        screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        lastTime2 = Random.Range(minRanStartLenght, maxRanStartLenght);
        pauseLenght = Random.Range(minRanPauseLenght, maxRanPauseLenght);
	}
	
	void Update ()
    {
        transform.Translate(Vector2.left * movementSpeed);

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

        if (shooting && transform.position.x > screenBottomLeft.x)
		{
			if (lastTime >= fireRate)
			{
                GameObject proj = Instantiate(projectile, transform.position + projectile.transform.position, projectile.transform.rotation);
                Destroy(proj, 5);
				lastTime = 0;
			}
			else
			{
				lastTime += Time.deltaTime;
			}
		}
	}
}
