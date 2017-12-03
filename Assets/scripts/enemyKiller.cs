using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKiller : MonoBehaviour {

    public int DmgStateAmount = 3;
    public float blinkDuration = 0.1f;
    public Color blinkingColor;
    public GameObject deathPlosion;

    int DamageState = 0;
    scoreCounter scoreCount;
    bool hitCoolDown = false;

    void Start()
    {
        scoreCount = GameObject.FindGameObjectWithTag("Score").GetComponent<scoreCounter>();
    }

    IEnumerator HitBlinking()
    {
        GetComponent<SpriteRenderer>().color = blinkingColor;
        yield return new WaitForSeconds(blinkDuration);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "PlayerProjectile")
        {
            Destroy(obj.gameObject);

            DamageState++;
            StartCoroutine("HitBlinking");

            if (DamageState >= DmgStateAmount)
            {
                scoreCount.AddScore();
				GameObject Explosion = Instantiate(deathPlosion, transform.position, deathPlosion.transform.rotation);
                Destroy(Explosion, 2);
                Destroy(this.gameObject);
            }
        }
    }
}
