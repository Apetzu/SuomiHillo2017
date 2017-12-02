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
    public float offsetSpawn = 1.5f;

	Vector2 screenBottomLeft;
    Vector2 screenRightTop;
    bool spawn = false;
    Vector2 lastHitPos;
    double lastTime = 0;

	void Start () 
    {
		screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));

        GetComponent<BoxCollider2D> ().size = new Vector2(Mathf.Abs(screenRightTop.x + tS.sideScreenBorder) * 2, 1);
		GetComponent<BoxCollider2D> ().offset = new Vector2 (0, screenBottomLeft.y - bottomScreenBorder);

        lastTime = coolDown;
	}

	void FixedUpdate () 
    {
        if (spawn)
        {
            int randItem = Random.Range(0, spawnableObjects.Length);

            GameObject item = Instantiate(spawnableObjects[randItem], new Vector2(lastHitPos.x, lastHitPos.y + offsetSpawn), spawnableObjects[randItem].transform.rotation);

            Vector2 dir = (new Vector3(0, screenRightTop.y, 0) - item.transform.position).normalized;
            item.GetComponent<Rigidbody2D>().AddForce(dir * itemForce);
            item.GetComponent<Rigidbody2D>().AddTorque(itemTorque);

            Destroy(item, 5);

            spawn = false;
        }

        lastTime += Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag != "Player")
        {
            if (obj.tag == "Bomb" && lastTime >= coolDown)
            {
                lastHitPos = obj.transform.position;
                spawn = true;
                lastTime = 0;
            }

            Destroy(obj.gameObject);
        }
    }
}
