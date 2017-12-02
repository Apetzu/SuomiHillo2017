using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour 
{
	public float movementSpeed = 5;

	Rigidbody2D rb;
	Vector2 screenBottomLeft;
	Vector2 screenRightTop;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
		screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
	}

	void FixedUpdate () 
	{
		rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed);

		transform.position = new Vector2(Mathf.Clamp(transform.position.x, screenBottomLeft.x, screenRightTop.x), Mathf.Clamp(transform.position.y, screenBottomLeft.y, screenRightTop.y));
	}
}
