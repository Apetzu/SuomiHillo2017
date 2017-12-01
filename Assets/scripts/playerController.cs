using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float movementSpeed = 5;

	Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed);
	}
}
