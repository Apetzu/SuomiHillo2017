using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour 
{

	public float movementSpeed = 5;

	Rigidbody2D rb;
    Vector2 bottomLeft;
    Vector2 rightTop;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        rightTop = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
	}

	void Update () 
	{
		rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, bottomLeft.x, rightTop.x), Mathf.Clamp(transform.position.y, bottomLeft.y, rightTop.y));
	}
}
