using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour 
{
	public float movementSpeed = 5f;
    public float fireRate = 0.5f;
    public float topClamp = 4;
    public float bottomClamp = 4;
    public int DmgStateAmount = 3;
    public float rateOverTimeDelta = 100;
    public float hitCoolDownTime = 2;
    public float blinkingRate = 0.1f;
    public Color blinkingColor;
    public GameObject bullet;
    public ParticleSystem pS;
    public scoreCounter sC;
    bool canShoot = true;
    public AudioSource shootSound;

	Rigidbody2D rb;
	Vector2 screenBottomLeft;
	Vector2 screenRightTop;
    int DamageState = 0;
    ParticleSystem.EmissionModule eM;
    double lastHitTime = 0;
    bool hitCoolDown = false;

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

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, screenBottomLeft.x, screenRightTop.x), Mathf.Clamp(transform.position.y, screenBottomLeft.y + bottomClamp, screenRightTop.y - topClamp));

        if (Input.GetButton("Trigger") && canShoot)
        {
            GameObject proj = Instantiate(bullet, transform.position + bullet.transform.position, bullet.transform.rotation);
            canShoot = false;
            StartCoroutine(FireRateTimer());
            Destroy(proj, 5);
        }

        if (lastHitTime >= hitCoolDownTime)
        {
            hitCoolDown = false;
            StopCoroutine(HitBlinking());
        }
        else
        {
            lastHitTime += Time.deltaTime;
        }
	}

    IEnumerator FireRateTimer()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
        shootSound.Play();
    }

    IEnumerator HitBlinking()
    {
        while (hitCoolDown)
        {
            GetComponent<SpriteRenderer>().color = blinkingColor;
            yield return new WaitForSeconds(blinkingRate);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(blinkingRate);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag != "PlayerProjectile" && obj.tag != "BG" && hitCoolDown == false)
        {
            lastHitTime = 0;
            hitCoolDown = true;
            StartCoroutine(HitBlinking());
            DamageState++;
            eM.rateOverTime = DamageState * rateOverTimeDelta;
            Destroy(obj.gameObject);
        }
        if (DamageState >= DmgStateAmount)
        {
            sC.GameOver();
            this.gameObject.SetActive(false);
        }
    }
}
