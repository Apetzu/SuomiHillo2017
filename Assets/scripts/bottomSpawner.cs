using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomSpawner : MonoBehaviour {

	void Start () 
    {
		
	}

	void Update () 
    {
		
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        // Spawn random shit and explosion
        Destroy(obj.gameObject);
    }
}
