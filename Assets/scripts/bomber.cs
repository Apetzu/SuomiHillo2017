using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber : MonoBehaviour 
{

    public float movementSpeed = 0.2f;
    public float fireRate = 0.1f;
    public GameObject projectile;
    public float lenght = 10;
    public float maxPos = 30;

    Rigidbody2D rb;
    double lastTime = 0;
    float posStart;

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        posStart = transform.position.x - Random.Range(1, maxPos);
	}
	
	void Update () 
    {
        transform.Translate(Vector2.left * movementSpeed);

        if (transform.position.x <= posStart && transform.position.x >= posStart - lenght)
        {
            if (lastTime >= fireRate)
            {
                GameObject spawned = Instantiate(projectile, new Vector2(transform.position.x - 1, transform.position.y), projectile.transform.rotation);
                lastTime = 0;
            }
            else
            {
                lastTime += Time.deltaTime;
            }
        }
	}
}
