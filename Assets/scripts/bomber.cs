using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber : MonoBehaviour {

    public float movementSpeed = 5;

    Rigidbody2D rb;

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
    {
        rb.AddForce(Vector2.right * movementSpeed);
	}
}
