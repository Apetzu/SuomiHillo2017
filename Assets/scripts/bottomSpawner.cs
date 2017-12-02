using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomSpawner : MonoBehaviour 
{
	public float bottomScreenBorder = 2;
    public topSpawner tS;
    public GameObject[] spawnableObjects;
    public float itemForce = 100;
    public float itemTorque = 5;
    public float coolDown = 2;

	Vector2 screenBottomLeft;
    bool spawn = false;
    Vector2 lastHitPos;
    double lastTime = 0;

	void Start () 
    {
		screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        GetComponent<BoxCollider2D> ().size = new Vector2(Mathf.Abs(screenBottomLeft.x - tS.sideScreenBorder) * 2, 1);
		GetComponent<BoxCollider2D> ().offset = new Vector2 (0, screenBottomLeft.y - bottomScreenBorder);
	}

	void FixedUpdate () 
    {
        if (spawn)
        {
            int randItem = Random.Range(0, spawnableObjects.Length - 1);

            GameObject item = Instantiate(spawnableObjects[randItem], new Vector2(lastHitPos.x, lastHitPos.y + 2), spawnableObjects[randItem].transform.rotation);
            item.GetComponent<Rigidbody2D>().AddForce(Vector2.up * itemForce);
            item.GetComponent<Rigidbody2D>().AddTorque(itemTorque);

            spawn = false;
        }
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag != "Player")
        {
            if (obj.tag == "Projectiles" && lastTime >= coolDown)
            {
                lastHitPos = obj.transform.position;
                spawn = true;
                lastTime = 0;
            }

            Destroy(obj.gameObject);
        }
    }
}
