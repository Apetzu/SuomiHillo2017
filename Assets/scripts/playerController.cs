using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour 
{
	public float movementSpeed = 5f;
    public float fireRate = 0.5f;
    public float topClamp = 5;
    public int DmgStateAmount = 3;
    public float rateOverTimeDelta = 50;

    public GameObject bullet;
    public ParticleSystem pS;
    bool canShoot = true;

	Rigidbody2D rb;
	Vector2 screenBottomLeft;
	Vector2 screenRightTop;
    int DamageState = 0;
    ParticleSystem.EmissionModule eM;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
		screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
        eM = pS.emission;
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

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (DamageState >= DmgStateAmount)
        {
            this.gameObject.SetActive(false);
        }
        if (obj.tag != "PlayerProjectile")
        {
            DamageState++;
            eM.rateOverTime = DamageState * rateOverTimeDelta;
            Destroy(obj.gameObject);
        }
    }
}
