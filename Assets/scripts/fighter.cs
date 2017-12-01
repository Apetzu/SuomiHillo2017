using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighter : MonoBehaviour {

    public float movementSpeed = 0.3f;

    void Start () 
    {
		
	}

	void Update () 
    {
        transform.Translate(Vector2.left * movementSpeed);
	}
}
