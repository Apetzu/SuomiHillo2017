using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomSpawner : MonoBehaviour 
{
	public float bottomScreenBorder = 2;
    public topSpawner tS;

	Vector2 screenBottomLeft;

	void Start () 
    {
		screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        GetComponent<BoxCollider2D> ().size = new Vector2(Mathf.Abs(screenBottomLeft.x - tS.sideScreenBorder) * 2, 1);
		GetComponent<BoxCollider2D> ().offset = new Vector2 (0, screenBottomLeft.y - bottomScreenBorder);
	}

	void Update () 
    {
		
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        // Spawn random shit and explosion
		if (obj.tag != "Player")
			Destroy(obj.gameObject);
    }
}
