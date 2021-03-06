﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_IrisNomal : Bullet {

	// Use this for initialization
	void Start () {
        directionVector = FavoriteFunction.VectorCalculator(pNum_Bullet, transform);
        bSpd = 60f; // 20의 속도  10의 속도 = 30f
        FavoriteFunction.ObjectRotation(directionVector, gameObject);

        AutoDestroy();
    }

    // Update is called once per frame
    void Update () {
        ShootBullet();

    }

    public override void ShootBullet()
    {
        transform.position += directionVector * bSpd * Time.deltaTime;
    }
}
