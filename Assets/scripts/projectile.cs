using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float movementSpeed = 0.5f;

    void Start()
    {
		
    }

    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed);
    }
}
