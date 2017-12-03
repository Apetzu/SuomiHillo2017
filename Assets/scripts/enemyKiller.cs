using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKiller : MonoBehaviour {

    public int DmgStateAmount = 3;
    scoreCounter scoreCount;

    int DamageState = 0;

    void Start()
    {
        scoreCount = GameObject.FindGameObjectWithTag("Score").GetComponent<scoreCounter>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "PlayerProjectile")
        {
            Destroy(obj.gameObject);

            DamageState++;

            if (DamageState >= DmgStateAmount)
            {
                scoreCount.AddScore();
                Destroy(this.gameObject);
            }
        }
    }
}
