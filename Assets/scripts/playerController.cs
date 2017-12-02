using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour 
{
	public float movementSpeed = 5f;
    public float fireRate = 0.5f;
    public float topClamp = 5;

    public GameObject bullet;
    bool canShoot = true;

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

		transform.position = new Vector2(Mathf.Clamp(transform.position.x, screenBottomLeft.x, screenRightTop.x), Mathf.Clamp(transform.position.y, screenBottomLeft.y, screenRightTop.y - topClamp));

        if (Input.GetButton("Trigger") && canShoot)
        {
            GameObject proj = Instantiate(bullet, transform.position + bullet.transform.position, bullet.transform.rotation);
            canShoot = false;
            StartCoroutine(FireRateTimer());
            Destroy(proj, 5);
        }
	}

    IEnumerator FireRateTimer()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
