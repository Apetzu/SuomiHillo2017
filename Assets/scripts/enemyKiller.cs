﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKiller : MonoBehaviour {

    public int DmgStateAmount = 3;
    public scoreCounter scoreCount;

    int DamageState = 0;

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
